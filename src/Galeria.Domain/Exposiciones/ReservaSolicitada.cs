namespace Galeria.Domain.Exposiciones;

/// <summary>Obra a reservar junto con la versión (RowVersion) que tenía cuando se armó la propuesta.</summary>
public sealed record ReservaSolicitada(int ObraId, byte[] RowVersion);
