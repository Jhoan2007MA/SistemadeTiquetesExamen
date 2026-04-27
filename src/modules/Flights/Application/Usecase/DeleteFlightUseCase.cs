using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Flights.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Flights.Application.Usecase;

public class DeleteFlightUseCase
{
    private readonly IFlightsRepository _repository;
    public DeleteFlightUseCase(IFlightsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Guid id) => await _repository.DeleteAsync(id);
}
