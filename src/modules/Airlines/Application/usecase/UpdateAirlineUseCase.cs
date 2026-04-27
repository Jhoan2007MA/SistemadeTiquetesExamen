using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airlines.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airlines.Application.Usecase;

public class UpdateAirlineUseCase
{
    private readonly IAirlinesRepository _repository;

    public UpdateAirlineUseCase(IAirlinesRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Airline airline)
    {
        await _repository.UpdateAsync(airline);
    }
}
