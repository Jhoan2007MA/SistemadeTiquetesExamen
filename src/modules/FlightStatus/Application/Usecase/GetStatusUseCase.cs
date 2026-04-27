using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightStatus.Application.Usecase;

public class GetStatusUseCase
{
    private readonly IFlightStatusRepository _repository;
    public GetStatusUseCase(IFlightStatusRepository repository) => _repository = repository;
    public async Task<IEnumerable<FlightStatusAggregate>> ExecuteGetAllAsync() => await _repository.GetAllAsync();
    public async Task<FlightStatusAggregate?> ExecuteGetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
}
