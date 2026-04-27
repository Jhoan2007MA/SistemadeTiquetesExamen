using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAvailability.Domain.Repositories;

public interface ISeatAvailabilityRepository
{
    Task<IEnumerable<SeatAvailabilityAggregate>> GetAllAsync();
    Task<SeatAvailabilityAggregate?> GetByIdAsync(Guid id);
    Task AddAsync(SeatAvailabilityAggregate availability);
    Task UpdateAsync(SeatAvailabilityAggregate availability);
    Task DeleteAsync(Guid id);
}
