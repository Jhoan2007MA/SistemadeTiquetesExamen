using System;

namespace SistemadeTiquetess.src.modules.Aircrafts.infrastructure.Entity;

/// <summary>
/// Modelo Anémico (Data Model) que representa a la Aeronave en la base de datos de infraestructura.
/// Esta clase está puramente pensada para Entity Framework Core y no contiene lógica de negocio.
/// </summary>
public class AircraftEntity
{
    public Guid Id { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Capacity { get; set; }
    public string Manufacturer { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
