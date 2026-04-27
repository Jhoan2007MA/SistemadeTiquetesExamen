using System;

namespace SistemadeTiquetess.src.modules.Airports.Infrastructure.Entity;

/// <summary>
/// Modelo Anémico (Data Model) que representa a un Aeropuerto en la base de datos de infraestructura.
/// </summary>
public class AirportEntity
{
    public Guid Id { get; set; }
    public string IataCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
