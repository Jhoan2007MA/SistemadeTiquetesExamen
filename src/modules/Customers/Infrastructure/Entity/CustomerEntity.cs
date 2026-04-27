using System;

namespace SistemadeTiquetess.src.modules.Customers.Infrastructure.Entity;

/// <summary>
/// Modelo Anémico (Data Model) correspondiente a base de datos de los Clientes.
/// Estructurado internamente sin lógica de negocio, destinado puramente a Entity Framework Core o el ORM usado.
/// </summary>
public class CustomerEntity
{
    public Guid Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string DocumentNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; }
}
