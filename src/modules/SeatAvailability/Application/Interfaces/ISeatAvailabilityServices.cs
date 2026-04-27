using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAvailability.Application.Interfaces;

public interface ISeatAvailabilityServices
{
    Task<IEnumerable<SeatAvailabilityAggregate>> GetAllAsync();
    Task<SeatAvailabilityAggregate?> GetByIdAsync(Guid id);
    Task<SeatAvailabilityAggregate> CreateAsync(SeatAvailabilityAggregate availability);
    Task UpdateAsync(SeatAvailabilityAggregate availability);
    Task DeleteAsync(Guid id);
}
