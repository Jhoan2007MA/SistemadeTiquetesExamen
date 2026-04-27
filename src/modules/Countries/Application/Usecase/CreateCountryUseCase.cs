using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Countries.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Countries.Application.Usecase;

public class CreateCountryUseCase
{
    private readonly ICountriesRepository _repository;

    public CreateCountryUseCase(ICountriesRepository repository)
    {
        _repository = repository;
    }

    public async Task<Country> ExecuteAsync(Country country)
    {
        await _repository.AddAsync(country);
        return country;
    }
}
