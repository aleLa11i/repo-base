namespace Galeria.Application.DTOs;

public sealed record ObraPropuestaDto(int Id, string Titulo, string Pintor, int AnchoCm, decimal ValorTasacion, byte[] RowVersion);
