using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Customers.Domain.Repositories;

/// <summary>
/// Contrato abstracto del Repositorio de persistencia atado directamente al Agregado 'Customer'.
/// Abstrae implementaciones SQL o NoSQL.
/// </summary>
public interface ICustomersRepository
{
    Task<Customer?> GetByIdAsync(Guid id);
    
    // Especializado en buscar el cliente por documento de identidad (ej: Cédula, Pasaporte, DNI)
    Task<Customer?> GetByDocumentNumberAsync(string documentNumber);
    
    Task<IEnumerable<Customer>> GetAllAsync();
    
    Task AddAsync(Customer customer);
    
    Task UpdateAsync(Customer customer);
    
    Task DeleteAsync(Guid id);
}
