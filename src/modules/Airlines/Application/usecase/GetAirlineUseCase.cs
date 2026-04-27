using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airlines.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Airlines.Application.Usecase;

public class GetAirlineUseCase
{
    private readonly IAirlinesRepository _repository;

    public GetAirlineUseCase(IAirlinesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Airline>> ExecuteGetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Airline?> ExecuteGetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
