namespace Galeria.Domain.Excepciones;

/// <summary>Traducción de dominio de DbUpdateConcurrencyException (Clase 6).</summary>
public sealed class ConflictoDeConcurrenciaException(string mensaje, Exception? inner = null)
    : Exception(mensaje, inner);
