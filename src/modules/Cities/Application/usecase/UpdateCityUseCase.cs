using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Cities.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Cities.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Cities.Application.Usecase;

public class UpdateCityUseCase
{
    private readonly ICitiesRepository _repository;

    public UpdateCityUseCase(ICitiesRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(City city)
    {
        await _repository.UpdateAsync(city);
    }
}
