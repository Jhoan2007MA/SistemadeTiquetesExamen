using System;
using SistemadeTiquetess.src.modules.FlightStatus.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;

public class FlightEntity
{
    public Guid Id { get; set; }
    public string FlightNumber { get; set; } = string.Empty;
    public Guid StatusId { get; set; }

    // Propiedad de navegación
    public virtual StatusEntity Status { get; set; } = null!;
}
