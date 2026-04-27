using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airports.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airports.Application.Usecase;

/// <summary>
/// Use case for retrieving airports.
/// Encapsulates the logic for fetching one or all airports.
/// </summary>
public class GetAirportUseCase
{
    private readonly IAirportsRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAirportUseCase"/> class.
    /// </summary>
    /// <param name="repository">The airport repository instance.</param>
    public GetAirportUseCase(IAirportsRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to retrieve all airports.
    /// </summary>
    /// <returns>A collection of airports.</returns>
    public async Task<IEnumerable<Airport>> ExecuteGetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    /// <summary>
    /// Executes the use case to retrieve a single airport by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the airport.</param>
    /// <returns>The airport, if found; otherwise, null.</returns>
    public async Task<Airport?> ExecuteGetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
