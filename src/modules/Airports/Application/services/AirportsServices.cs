using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airports.Application.Interfaces;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airports.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airports.Application.Services;

/// <summary>
/// Implementation of the Airport services.
/// Handles the business logic for Airport operations.
/// </summary>
public class AirportsServices : IAirportsServices
{
    private readonly IAirportsRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="AirportsServices"/> class.
    /// </summary>
    /// <param name="repository">The repository used for data access.</param>
    public AirportsServices(IAirportsRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Retrieves all airports from the repository.
    /// </summary>
    /// <returns>An enumerable collection of airports.</returns>
    public async Task<IEnumerable<Airport>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    /// <summary>
    /// Retrieves a specific airport by its ID.
    /// </summary>
    /// <param name="id">The ID of the airport to retrieve.</param>
    /// <returns>The airport if found; otherwise, null.</returns>
    public async Task<Airport?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    /// <summary>
    /// Creates a new airport by saving it via the repository.
    /// </summary>
    /// <param name="airport">The airport to create.</param>
    /// <returns>The newly created airport.</returns>
    public async Task<Airport> CreateAsync(Airport airport)
    {
        await _repository.AddAsync(airport);
        return airport;
    }

    /// <summary>
    /// Updates the details of an existing airport.
    /// </summary>
    /// <param name="airport">The airport entity containing the updated details.</param>
    public async Task UpdateAsync(Airport airport)
    {
        await _repository.UpdateAsync(airport);
    }

    /// <summary>
    /// Deletes an airport using its unique ID.
    /// </summary>
    /// <param name="id">The ID of the airport to delete.</param>
    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
