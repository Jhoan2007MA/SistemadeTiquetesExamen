using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airlines.Application.Usecase;

public class DeleteAirlineUseCase
{
    private readonly IAirlinesRepository _repository;

    public DeleteAirlineUseCase(IAirlinesRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
