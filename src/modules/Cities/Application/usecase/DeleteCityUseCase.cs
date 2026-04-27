using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Cities.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Cities.Application.Usecase;

public class DeleteCityUseCase
{
    private readonly ICitiesRepository _repository;

    public DeleteCityUseCase(ICitiesRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
