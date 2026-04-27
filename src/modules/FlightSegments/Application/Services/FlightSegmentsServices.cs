using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Application.Interfaces;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightSegments.Application.Services;

public class FlightSegmentsServices : IFlightSegmentsServices
{
    private readonly IFlightSegmentsRepository _repository;
    public FlightSegmentsServices(IFlightSegmentsRepository repository) => _repository = repository;

    public async Task<IEnumerable<FlightSegment>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<FlightSegment?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<FlightSegment> CreateAsync(FlightSegment segment)
    {
        await _repository.AddAsync(segment);
        return segment;
    }
    public async Task UpdateAsync(FlightSegment segment) => await _repository.UpdateAsync(segment);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
