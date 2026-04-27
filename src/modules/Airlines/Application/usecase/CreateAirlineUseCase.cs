using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airlines.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airlines.Application.Usecase;

public class CreateAirlineUseCase
{
    private readonly IAirlinesRepository _repository;

    public CreateAirlineUseCase(IAirlinesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Airline> ExecuteAsync(Airline airline)
    {
        await _repository.AddAsync(airline);
        return airline;
    }
}
