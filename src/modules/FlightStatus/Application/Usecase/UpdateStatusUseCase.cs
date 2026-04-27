using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightStatus.Application.Usecase;

public class UpdateStatusUseCase
{
    private readonly IFlightStatusRepository _repository;
    public UpdateStatusUseCase(IFlightStatusRepository repository) => _repository = repository;
    public async Task ExecuteAsync(FlightStatusAggregate status) => await _repository.UpdateAsync(status);
}
