namespace Galeria.Domain.Enums;

/// <summary>Criterio secundario cuando dos selecciones tienen el mismo valor total.</summary>
public enum ReglaDesempate
{
    /// <summary>A igual valor, preferir la selección que ocupa menos pared.</summary>
    MenorAnchoTotal = 0,

    /// <summary>A igual valor, preferir la selección con más obras.</summary>
    MayorCantidadObras = 1,

    /// <summary>A igual valor, preferir la selección con menos obras.</summary>
    MenorCantidadObras = 2
}
