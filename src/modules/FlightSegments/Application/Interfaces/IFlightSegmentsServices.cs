using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.FlightSegments.Application.Interfaces;

public interface IFlightSegmentsServices
{
    Task<IEnumerable<FlightSegment>> GetAllAsync();
    Task<FlightSegment?> GetByIdAsync(Guid id);
    Task<FlightSegment> CreateAsync(FlightSegment segment);
    Task UpdateAsync(FlightSegment segment);
    Task DeleteAsync(Guid id);
}
