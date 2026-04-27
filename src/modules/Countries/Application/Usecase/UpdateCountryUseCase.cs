using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Countries.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Countries.Application.Usecase;

public class UpdateCountryUseCase
{
    private readonly ICountriesRepository _repository;

    public UpdateCountryUseCase(ICountriesRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Country country)
    {
        await _repository.UpdateAsync(country);
    }
}
