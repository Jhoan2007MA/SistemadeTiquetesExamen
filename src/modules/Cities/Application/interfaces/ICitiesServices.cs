using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Cities.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Cities.Application.Interfaces;

/// <summary>
/// Contrato del servicio de aplicación que encapusla la lógica de negocio 
/// para el módulo de Ciudades (Cities). Las diferentes capas de presentación (UI, API)
/// deberán consumir siempre esta abstracción y no la base de datos directamente.
/// </summary>
public interface ICitiesServices
{
    /// <summary>
    /// Consulta todas las ciudades activas registradas en el sistema.
    /// </summary>
    Task<IEnumerable<City>> GetAllAsync();

    /// <summary>
    /// Intenta buscar una ciudad por medio de su identificador único (ID).
    /// </summary>
    Task<City?> GetByIdAsync(Guid id);

    /// <summary>
    /// Procesa el registro de una nueva ciudad verificando reglas de negocio primero.
    /// </summary>
    Task<City> CreateAsync(City city);

    /// <summary>
    /// Actualiza información de una ciudad existente mediante su entidad.
    /// </summary>
    Task UpdateAsync(City city);

    /// <summary>
    /// Retira una ciudad de los registros operativos consultando su ID.
    /// </summary>
    Task DeleteAsync(Guid id);
}
