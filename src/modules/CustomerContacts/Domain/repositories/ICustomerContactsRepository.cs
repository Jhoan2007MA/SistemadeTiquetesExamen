using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Domain.Repositories;

/// <summary>
/// Contrato del Repositorio para el manejo de persistencia de Contactos de los Clientes.
/// </summary>
public interface ICustomerContactsRepository
{
    Task<CustomerContact?> GetByIdAsync(Guid id);
    
    // Método contextual: permite encontrar todos los métodos de contacto asociados a un cliente
    Task<IEnumerable<CustomerContact>> GetByCustomerIdAsync(Guid customerId);
    
    Task<IEnumerable<CustomerContact>> GetAllAsync();
    
    Task AddAsync(CustomerContact customerContact);
    
    Task UpdateAsync(CustomerContact customerContact);
    
    Task DeleteAsync(Guid id);
}
