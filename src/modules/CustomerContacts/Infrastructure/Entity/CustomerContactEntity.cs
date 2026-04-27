using System;
using SistemadeTiquetess.src.modules.Customers.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Infrastructure.Entity;

/// <summary>
/// Modelo Anémico (Data Model) base de datos de los Contactos de Cliente.
/// Estructurado internamente sin lógica de negocio, destinado puramente a Entity Framework Core o el ORM usado.
/// </summary>
public class CustomerContactEntity
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    // Propiedad de navegación
    public virtual CustomerEntity Customer { get; set; } = null!;
}
