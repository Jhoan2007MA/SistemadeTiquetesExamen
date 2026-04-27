using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightStatus.Application.Usecase;

public class DeleteStatusUseCase
{
    private readonly IFlightStatusRepository _repository;
    public DeleteStatusUseCase(IFlightStatusRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Guid id) => await _repository.DeleteAsync(id);
}
