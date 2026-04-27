using System;

namespace SistemadeTiquetess.src.modules.Countries.Infrastructure.Entity;

/// <summary>
/// Modelo Anémico (Data Model) de base de datos para los Países.
/// Estructurado internamente sin lógica de negocio, destinado puramente a Entity Framework Core o el ORM usado.
/// </summary>
public class CountryEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
