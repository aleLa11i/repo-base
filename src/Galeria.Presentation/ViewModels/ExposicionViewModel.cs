using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Galeria.Application.DTOs;
using Galeria.Application.Exposiciones.Algoritmos;
using Galeria.Application.Mappers;
using Galeria.Domain.Entities;
using Galeria.Domain.Enums;
using Galeria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Galeria.Presentation.ViewModels;

// Implementado según RF-07 (consulta directa al contexto por performance).
public partial class ExposicionViewModel : ObservableObject
{
    private readonly GaleriaDbContext _db;
    private readonly ArmadorExposicionGreedy _armador = new();
    private List<Obra> _disponibles = [];
    private List<Obra> _seleccionadas = [];

    public ExposicionViewModel(GaleriaDbContext db)
    {
        _db = db;
        CapacidadCm = 1000;
        CargarObras();
    }

    public ObservableCollection<ObraPropuestaDto> Disponibles { get; } = [];
    public ObservableCollection<ObraPropuestaDto> Propuesta { get; } = [];

    [ObservableProperty] public partial int CapacidadCm { get; set; }
    [ObservableProperty] public partial decimal ValorTotal { get; set; }
    [ObservableProperty] public partial int AnchoTotalCm { get; set; }
    [ObservableProperty] public partial string? MensajeError { get; set; }
    [ObservableProperty] public partial bool EstaOcupado { get; set; }

    private async void CargarObras()
    {
        EstaOcupado = true;
        await Task.Run(() =>
        {
            _disponibles = _db.Obras
                .Include(o => o.Pintor)
                .Where(o => o.Estado == EstadoObra.Disponible)
                .ToList();

            foreach (var obra in _disponibles)
                Disponibles.Add(obra.ADto());
        });
        EstaOcupado = false;
    }

    [RelayCommand]
    private void Armar()
    {
        var resultado = _armador.Armar(_disponibles, CapacidadCm);
        _seleccionadas = [.. resultado.Seleccionadas];

        Propuesta.Clear();
        foreach (var obra in _seleccionadas)
            Propuesta.Add(obra.ADto());

        ValorTotal = resultado.ValorTotal;
        AnchoTotalCm = resultado.AnchoTotalCm;
    }

    [RelayCommand]
    private async Task Reservar()
    {
        foreach (var obra in _seleccionadas)
            obra.Reservar();

        await _db.SaveChangesAsync();
        Propuesta.Clear();
    }
}
