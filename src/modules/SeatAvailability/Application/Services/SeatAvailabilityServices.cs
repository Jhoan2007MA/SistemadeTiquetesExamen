using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAvailability.Application.Interfaces;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Aggregate;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.SeatAvailability.Application.Services;

public class SeatAvailabilityServices : ISeatAvailabilityServices
{
    private readonly ISeatAvailabilityRepository _repository;
    public SeatAvailabilityServices(ISeatAvailabilityRepository repository) => _repository = repository;

    public async Task<IEnumerable<SeatAvailabilityAggregate>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<SeatAvailabilityAggregate?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<SeatAvailabilityAggregate> CreateAsync(SeatAvailabilityAggregate availability)
    {
        await _repository.AddAsync(availability);
        return availability;
    }
    public async Task UpdateAsync(SeatAvailabilityAggregate availability) => await _repository.UpdateAsync(availability);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
