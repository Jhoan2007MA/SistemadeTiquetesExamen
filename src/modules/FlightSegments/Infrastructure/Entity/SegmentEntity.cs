using System;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.Airports.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.FlightSegments.Infrastructure.Entity;

public class SegmentEntity
{
    public Guid Id { get; set; }
    public Guid FlightId { get; set; }
    public Guid OriginAirportId { get; set; }
    public Guid DestinationAirportId { get; set; }

    // Propiedades de navegación
    public virtual FlightEntity Flight { get; set; } = null!;
    public virtual AirportEntity OriginAirport { get; set; } = null!;
    public virtual AirportEntity DestinationAirport { get; set; } = null!;
}
