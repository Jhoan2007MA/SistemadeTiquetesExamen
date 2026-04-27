using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightStatus.Application.Interfaces;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightStatus.Application.Services;

public class FlightStatusServices : IFlightStatusServices
{
    private readonly IFlightStatusRepository _repository;

    public FlightStatusServices(IFlightStatusRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FlightStatusAggregate>> GetAllAsync() => await _repository.GetAllAsync();
    
    public async Task<FlightStatusAggregate?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);

    public async Task<FlightStatusAggregate> CreateAsync(FlightStatusAggregate status)
    {
        await _repository.AddAsync(status);
        return status;
    }

    public async Task UpdateAsync(FlightStatusAggregate status) => await _repository.UpdateAsync(status);

    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
