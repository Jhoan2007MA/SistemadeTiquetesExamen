using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airports.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airports.Application.Usecase;

/// <summary>
/// Use case for deleting an Airport.
/// Responsible for the removal logic.
/// </summary>
public class DeleteAirportUseCase
{
    private readonly IAirportsRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteAirportUseCase"/> class.
    /// </summary>
    /// <param name="repository">The airport repository instance.</param>
    public DeleteAirportUseCase(IAirportsRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to delete an airport by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the airport to delete.</param>
    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
