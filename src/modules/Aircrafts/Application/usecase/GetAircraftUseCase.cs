using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Aircrafts.Application.Usecase;

public class GetAircraftUseCase
{
    private readonly IAircraftsRepository _repository;

    public GetAircraftUseCase(IAircraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Aircraft>> ExecuteGetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Aircraft?> ExecuteGetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
