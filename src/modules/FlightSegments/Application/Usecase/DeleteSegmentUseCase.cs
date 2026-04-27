using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.FlightSegments.Application.Usecase;

public class DeleteSegmentUseCase
{
    private readonly IFlightSegmentsRepository _repository;
    public DeleteSegmentUseCase(IFlightSegmentsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Guid id) => await _repository.DeleteAsync(id);
}
