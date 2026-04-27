using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.FlightStatus.Domain.Repositories;

public interface IFlightStatusRepository
{
    Task<IEnumerable<FlightStatusAggregate>> GetAllAsync();
    Task<FlightStatusAggregate?> GetByIdAsync(Guid id);
    Task AddAsync(FlightStatusAggregate status);
    Task UpdateAsync(FlightStatusAggregate status);
    Task DeleteAsync(Guid id);
}
