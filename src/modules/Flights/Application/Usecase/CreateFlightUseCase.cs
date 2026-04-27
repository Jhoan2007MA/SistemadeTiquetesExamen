using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Flights.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Flights.Application.Usecase;

public class CreateFlightUseCase
{
    private readonly IFlightsRepository _repository;
    public CreateFlightUseCase(IFlightsRepository repository) => _repository = repository;
    public async Task<Flight> ExecuteAsync(Flight flight)
    {
        await _repository.AddAsync(flight);
        return flight;
    }
}
