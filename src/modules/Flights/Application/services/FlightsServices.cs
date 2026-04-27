using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Flights.Application.Interfaces;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Flights.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Flights.Application.Services;

public class FlightsServices : IFlightsServices
{
    private readonly IFlightsRepository _repository;
    public FlightsServices(IFlightsRepository repository) => _repository = repository;

    public async Task<IEnumerable<Flight>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Flight?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<Flight> CreateAsync(Flight flight)
    {
        await _repository.AddAsync(flight);
        return flight;
    }
    public async Task UpdateAsync(Flight flight) => await _repository.UpdateAsync(flight);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
