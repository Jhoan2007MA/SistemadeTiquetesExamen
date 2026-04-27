using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightSegments.Application.Usecase;

public class CreateSegmentUseCase
{
    private readonly IFlightSegmentsRepository _repository;
    public CreateSegmentUseCase(IFlightSegmentsRepository repository) => _repository = repository;
    public async Task<FlightSegment> ExecuteAsync(FlightSegment segment)
    {
        await _repository.AddAsync(segment);
        return segment;
    }
}
