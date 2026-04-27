using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.FlightStatus.Application.Interfaces;

public interface IFlightStatusServices
{
    Task<IEnumerable<FlightStatusAggregate>> GetAllAsync();
    Task<FlightStatusAggregate?> GetByIdAsync(Guid id);
    Task<FlightStatusAggregate> CreateAsync(FlightStatusAggregate status);
    Task UpdateAsync(FlightStatusAggregate status);
    Task DeleteAsync(Guid id);
}
