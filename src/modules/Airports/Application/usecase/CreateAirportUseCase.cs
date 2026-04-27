 using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airports.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airports.Application.Usecase;

/// <summary>
/// Use case for creating a new Airport.
/// Encapsulates the specific business rules for this operation.
/// </summary>
public class CreateAirportUseCase
{
    private readonly IAirportsRepository _repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateAirportUseCase"/> class.
    /// </summary>
    /// <param name="repository">The airport repository instance.</param>
    public CreateAirportUseCase(IAirportsRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Executes the use case to create an airport.
    /// </summary>
    /// <param name="airport">The airport to create.</param>
    /// <returns>The successfully created airport.</returns>
    public async Task<Airport> ExecuteAsync(Airport airport)
    {
        await _repository.AddAsync(airport);
        return airport;
    }
}
