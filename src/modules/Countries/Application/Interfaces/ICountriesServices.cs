using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Countries.Application.Interfaces;

/// <summary>
/// Contrato del servicio de aplicación que encapusla la lógica de negocio 
/// para el módulo de Países (Countries). Las diferentes capas de presentación (UI, API)
/// deberán consumir siempre esta abstracción y no la base de datos directamente.
/// </summary>
public interface ICountriesServices
{
    /// <summary>
    /// Consulta todos los países activos registrados en el sistema.
    /// </summary>
    Task<IEnumerable<Country>> GetAllAsync();

    /// <summary>
    /// Intenta buscar un país por medio de su identificador único (ID).
    /// </summary>
    Task<Country?> GetByIdAsync(Guid id);

    /// <summary>
    /// Procesa el registro de un nuevo país verificando reglas de negocio primero.
    /// </summary>
    Task<Country> CreateAsync(Country country);

    /// <summary>
    /// Actualiza información de un país existente mediante su entidad.
    /// </summary>
    Task UpdateAsync(Country country);

    /// <summary>
    /// Busca un país por su código ISO.
    /// </summary>
    Task<Country?> GetByCodeAsync(string code);

    /// <summary>
    /// Retira un país de los registros operativos consultando su ID.
    /// </summary>
    Task DeleteAsync(Guid id);
}
