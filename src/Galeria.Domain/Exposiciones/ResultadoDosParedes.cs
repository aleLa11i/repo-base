namespace Galeria.Domain.Exposiciones;

public sealed record ResultadoDosParedes(ResultadoExposicion ParedA, ResultadoExposicion ParedB)
{
    public decimal ValorTotal => ParedA.ValorTotal + ParedB.ValorTotal;
}
