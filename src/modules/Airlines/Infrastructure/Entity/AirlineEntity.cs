using System;

namespace SistemadeTiquetess.src.modules.Airlines.infrastructure.Entity;

/// <summary>
/// Modelo Anémico (Data Model) base de datos de la Aerolínea.
/// Estructurado internamente sin lógica de negocio, destinado puramente a Entity Framework Core o el ORM usado.
/// </summary>
public class AirlineEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
