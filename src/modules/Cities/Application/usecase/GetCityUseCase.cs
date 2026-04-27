using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Cities.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Cities.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Cities.Application.Usecase;

public class GetCityUseCase
{
    private readonly ICitiesRepository _repository;

    public GetCityUseCase(ICitiesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<City>> ExecuteGetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<City?> ExecuteGetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
