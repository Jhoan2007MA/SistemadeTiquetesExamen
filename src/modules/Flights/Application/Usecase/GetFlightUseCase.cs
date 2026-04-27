using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Flights.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Flights.Application.Usecase;

public class GetFlightUseCase
{
    private readonly IFlightsRepository _repository;
    public GetFlightUseCase(IFlightsRepository repository) => _repository = repository;
    public async Task<IEnumerable<Flight>> ExecuteGetAllAsync() => await _repository.GetAllAsync();
    public async Task<Flight?> ExecuteGetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
}
