using System.ComponentModel.DataAnnotations;
using Galeria.Domain.Enums;
using Galeria.Domain.Excepciones;

namespace Galeria.Domain.Entities;

public sealed class Obra
{
    private Obra() { } // EF Core

    public Obra(string titulo, int pintorId, int anchoCm, decimal valorTasacion, int anioCreacion)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(titulo);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(anchoCm);
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(valorTasacion);
        ArgumentOutOfRangeException.ThrowIfLessThan(anioCreacion, 1000);

        Titulo = titulo.Trim();
        PintorId = pintorId;
        AnchoCm = anchoCm;
        ValorTasacion = valorTasacion;
        AnioCreacion = anioCreacion;
        Estado = EstadoObra.Disponible;
    }

    public int Id { get; private set; }
    public string Titulo { get; private set; } = string.Empty;
    public int PintorId { get; private set; }
    public Pintor? Pintor { get; private set; }

    /// <summary>Pared que ocupa la obra, en centímetros (incluye marco y separación).</summary>
    public int AnchoCm { get; private set; }

    public decimal ValorTasacion { get; private set; }
    public int AnioCreacion { get; private set; }
    public EstadoObra Estado { get; private set; }

    // Control de concurrencia optimista (ver Clase 6).
    [Timestamp]
    public byte[]? RowVersion { get; private set; }

    /// <summary>Regla de negocio: la obra puede exhibirse si está disponible y su tasación alcanza el umbral.</summary>
    public bool EsExponible(decimal umbralTasacion) =>
        Estado == EstadoObra.Disponible && ValorTasacion >= umbralTasacion;

    public void Reservar()
    {
        if (Estado != EstadoObra.Disponible)
            throw new ReglaDeNegocioException($"La obra '{Titulo}' no está disponible (estado actual: {Estado}).");

        Estado = EstadoObra.Reservada;
    }

    public void MarcarVendida()
    {
        if (Estado == EstadoObra.Vendida)
            throw new ReglaDeNegocioException($"La obra '{Titulo}' ya fue vendida.");

        Estado = EstadoObra.Vendida;
    }

    public void ActualizarTasacion(decimal nuevoValor)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(nuevoValor);
        if (Estado == EstadoObra.Vendida)
            throw new ReglaDeNegocioException("No se puede retasar una obra vendida.");

        ValorTasacion = nuevoValor;
    }
}
