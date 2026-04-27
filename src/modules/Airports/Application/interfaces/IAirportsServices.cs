using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Airports.Application.Interfaces;

/// <summary>
/// Interface that defines the contract for Airport services.
/// </summary>
public interface IAirportsServices
{
    /// <summary>
    /// Retrieves all airports asynchronously.
    /// </summary>
    /// <returns>A collection of airports.</returns>
    Task<IEnumerable<Airport>> GetAllAsync();

    /// <summary>
    /// Retrieves a specific airport by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the airport.</param>
    /// <returns>The requested airport, or null if not found.</returns>
    Task<Airport?> GetByIdAsync(Guid id);

    /// <summary>
    /// Creates a new airport asynchronously.
    /// </summary>
    /// <param name="airport">The airport entity to create.</param>
    /// <returns>The created airport entity.</returns>
    Task<Airport> CreateAsync(Airport airport);

    /// <summary>
    /// Updates an existing airport asynchronously.
    /// </summary>
    /// <param name="airport">The airport entity with updated information.</param>
    Task UpdateAsync(Airport airport);

    /// <summary>
    /// Deletes an airport by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the airport to delete.</param>
    Task DeleteAsync(Guid id);
}
