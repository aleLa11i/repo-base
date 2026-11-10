using Galeria.Domain.Exposiciones;

namespace Galeria.Application.Exposiciones.ReservarObras;

public sealed record ReservarObrasCommand(IReadOnlyList<ReservaSolicitada> Obras);
