using System.Text;
using Galeria.Application.Abstracciones;
using Galeria.Application.DTOs;

namespace Galeria.Infrastructure.Xml;

/// <summary>Arma el XML a mano: más rápido y sin dependencias que XDocument.</summary>
public sealed class ExportadorPropuestaXml : IExportadorPropuesta
{
    public Task<string> ExportarAsync(PropuestaExposicionDto propuesta, CancellationToken ct = default)
    {
        var sb = new StringBuilder();
        sb.AppendLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
        sb.AppendLine($"<Exposicion capacidadCm=\"{propuesta.CapacidadCm}\" valorTotal=\"{propuesta.ValorTotal}\">");

        foreach (var obra in propuesta.Obras)
        {
            sb.AppendLine($"  <Obra id=\"{obra.Id}\">");
            sb.AppendLine($"    <Titulo>{obra.Titulo}</Titulo>");
            sb.AppendLine($"    <Valor>{obra.ValorTasacion}</Valor>");
            sb.AppendLine($"    <Pintor>{obra.Pintor}</Pintor>");
            sb.AppendLine($"    <AnchoCm>{obra.AnchoCm}</AnchoCm>");
            sb.AppendLine("  </Obra>");
        }

        sb.AppendLine("</Exposicion>");
        return Task.FromResult(sb.ToString());
    }
}
