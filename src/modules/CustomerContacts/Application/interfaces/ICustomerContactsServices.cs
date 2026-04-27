using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Application.Interfaces;

/// <summary>
/// Contrato del servicio de aplicación que encapusla la lógica de negocio 
/// para el módulo de Contactos del Cliente (CustomerContacts). Las capas de presentación (UI, API)
/// deberán consumir siempre esta abstracción y no la base de datos directamente.
/// </summary>
public interface ICustomerContactsServices
{
    /// <summary>
    /// Consulta todos los contactos de cliente registrados en el sistema.
    /// </summary>
    Task<IEnumerable<CustomerContact>> GetAllAsync();

    /// <summary>
    /// Intenta buscar un contacto de cliente por medio de su identificador único (ID).
    /// </summary>
    Task<CustomerContact?> GetByIdAsync(Guid id);

    /// <summary>
    /// Procesa el registro de un nuevo contacto verificando reglas de negocio primero.
    /// </summary>
    Task<CustomerContact> CreateAsync(CustomerContact customerContact);

    /// <summary>
    /// Actualiza información de un contacto de cliente existente mediante su entidad.
    /// </summary>
    Task UpdateAsync(CustomerContact customerContact);

    /// <summary>
    /// Retira un contacto de cliente de los registros operativos consultando su ID.
    /// </summary>
    Task DeleteAsync(Guid id);
}
