using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Application.Interfaces;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Aircrafts.Application.Services;

public class AircraftsServices : IAircraftsServices
{
    private readonly IAircraftsRepository _repository;

    public AircraftsServices(IAircraftsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Aircraft>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Aircraft?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Aircraft> CreateAsync(Aircraft aircraft)
    {
        await _repository.AddAsync(aircraft);
        return aircraft;
    }

    public async Task UpdateAsync(Aircraft aircraft)
    {
        await _repository.UpdateAsync(aircraft);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
