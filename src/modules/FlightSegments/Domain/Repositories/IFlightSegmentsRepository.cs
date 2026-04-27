using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.FlightSegments.Domain.Repositories;

public interface IFlightSegmentsRepository
{
    Task<IEnumerable<FlightSegment>> GetAllAsync();
    Task<FlightSegment?> GetByIdAsync(Guid id);
    Task AddAsync(FlightSegment segment);
    Task UpdateAsync(FlightSegment segment);
    Task DeleteAsync(Guid id);
}
