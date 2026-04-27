using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Aircrafts.Application.Usecase;

public class CreateAircraftUseCase
{
    private readonly IAircraftsRepository _repository;

    public CreateAircraftUseCase(IAircraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Aircraft> ExecuteAsync(Aircraft aircraft)
    {
        await _repository.AddAsync(aircraft);
        return aircraft;
    }
}
