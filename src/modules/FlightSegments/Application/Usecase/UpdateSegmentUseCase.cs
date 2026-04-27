using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightSegments.Application.Usecase;

public class UpdateSegmentUseCase
{
    private readonly IFlightSegmentsRepository _repository;
    public UpdateSegmentUseCase(IFlightSegmentsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(FlightSegment segment) => await _repository.UpdateAsync(segment);
}
