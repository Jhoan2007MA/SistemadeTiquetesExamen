using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Flights.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Flights.Application.Usecase;

public class UpdateFlightUseCase
{
    private readonly IFlightsRepository _repository;
    public UpdateFlightUseCase(IFlightsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Flight flight) => await _repository.UpdateAsync(flight);
}
