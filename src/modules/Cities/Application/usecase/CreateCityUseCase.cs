using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Cities.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Cities.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Cities.Application.Usecase;

public class CreateCityUseCase
{
    private readonly ICitiesRepository _repository;

    public CreateCityUseCase(ICitiesRepository repository)
    {
        _repository = repository;
    }

    public async Task<City> ExecuteAsync(City city)
    {
        await _repository.AddAsync(city);
        return city;
    }
}
