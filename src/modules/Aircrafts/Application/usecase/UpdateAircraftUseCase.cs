using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Aircrafts.Application.Usecase;

public class UpdateAircraftUseCase
{
    private readonly IAircraftsRepository _repository;

    public UpdateAircraftUseCase(IAircraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Aircraft aircraft)
    {
        await _repository.UpdateAsync(aircraft);
    }
}
