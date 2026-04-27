using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Application.Interfaces;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airlines.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airlines.Application.Services;

public class AirlinesServices : IAirlinesServices
{
    private readonly IAirlinesRepository _repository;

    public AirlinesServices(IAirlinesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Airline>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Airline?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Airline> CreateAsync(Airline airline)
    {
        await _repository.AddAsync(airline);
        return airline;
    }

    public async Task UpdateAsync(Airline airline)
    {
        await _repository.UpdateAsync(airline);
    }

    public async Task<Airline?> GetByCodeAsync(string code)
    {
        return await _repository.GetByCodeAsync(code);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
