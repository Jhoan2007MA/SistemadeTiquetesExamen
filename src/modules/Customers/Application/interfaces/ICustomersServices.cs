using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Customers.Application.Interfaces;

/// <summary>
/// Contrato abstracto del servicio de aplicación que encapusla la lógica de negocio 
/// para el módulo de Clientes (Customers). Las diferentes capas de presentación (UI, API)
/// deberán consumir siempre esta abstracción y no la base de datos directamente exploratoria.
/// </summary>
public interface ICustomersServices
{
    /// <summary>
    /// Consulta todos los clientes registrados y activos en el sistema.
    /// </summary>
    Task<IEnumerable<Customer>> GetAllAsync();

    /// <summary>
    /// Intenta buscar un cliente por medio de su identificador único (ID).
    /// </summary>
    Task<Customer?> GetByIdAsync(Guid id);

    /// <summary>
    /// Procesa el registro de un nuevo cliente verificando reglas de negocio primero.
    /// </summary>
    Task<Customer> CreateAsync(Customer customer);

    /// <summary>
    /// Actualiza información de un cliente existente mediante su entidad controlada.
    /// </summary>
    Task UpdateAsync(Customer customer);

    /// <summary>
    /// Retira un cliente de los registros operativos consultando su ID.
    /// </summary>
    Task DeleteAsync(Guid id);
}
