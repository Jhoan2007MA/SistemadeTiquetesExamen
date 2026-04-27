using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airports.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airports.Application.Usecase;

/// <summary>
/// Use case for updating an existing Airport.
/// Handles the business rules associated with modification.
/// </summary>
public class UpdateAirportUseCase
{
    private readonly IAirportsRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateAirportUseCase"/> class.
    /// </summary>
    /// <param name="repository">The airport repository instance.</param>
    public UpdateAirportUseCase(IAirportsRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to update an airport's details.
    /// </summary>
    /// <param name="airport">The airport object with updated data.</param>
    public async Task ExecuteAsync(Airport airport)
    {
        await _repository.UpdateAsync(airport);
    }
}
