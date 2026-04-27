using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Aircrafts.Application.Usecase;

public class DeleteAircraftUseCase
{
    private readonly IAircraftsRepository _repository;

    public DeleteAircraftUseCase(IAircraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
