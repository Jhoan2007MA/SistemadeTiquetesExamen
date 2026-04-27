using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightSegments.Application.Usecase;

public class GetSegmentUseCase
{
    private readonly IFlightSegmentsRepository _repository;
    public GetSegmentUseCase(IFlightSegmentsRepository repository) => _repository = repository;
    public async Task<IEnumerable<FlightSegment>> ExecuteGetAllAsync() => await _repository.GetAllAsync();
    public async Task<FlightSegment?> ExecuteGetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
}
