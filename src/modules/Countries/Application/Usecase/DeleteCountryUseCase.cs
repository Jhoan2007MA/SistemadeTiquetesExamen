using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Countries.Application.Usecase;

public class DeleteCountryUseCase
{
    private readonly ICountriesRepository _repository;

    public DeleteCountryUseCase(ICountriesRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
