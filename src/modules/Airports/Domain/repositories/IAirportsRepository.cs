using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Airports.Domain.Repositories;

/// <summary>
/// Contrato del repositorio para el agregado Airport (Aeropuerto).
/// Abstrae la persistencia de datos del modelo de dominio.
/// </summary>
public interface IAirportsRepository
{
    /// <summary>
    /// Obtiene un aeropuerto específico por su identificador único.
    /// </summary>
    Task<Airport?> GetByIdAsync(Guid id);

    /// <summary>
    /// Obtiene un aeropuerto por su código IATA.
    /// </summary>
    Task<Airport?> GetByIataCodeAsync(string iataCode);

    /// <summary>
    /// Obtiene el listado completo de aeropuertos.
    /// </summary>
    Task<IEnumerable<Airport>> GetAllAsync();

    /// <summary>
    /// Agrega un nuevo aeropuerto.
    /// </summary>
    Task AddAsync(Airport airport);

    /// <summary>
    /// Actualiza un aeropuerto existente.
    /// </summary>
    Task UpdateAsync(Airport airport);

    /// <summary>
    /// Elimina un aeropuerto por su identificador.
    /// </summary>
    Task DeleteAsync(Guid id);
}
