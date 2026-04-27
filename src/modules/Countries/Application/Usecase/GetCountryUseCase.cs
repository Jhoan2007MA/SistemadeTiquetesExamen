using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Countries.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Countries.Application.Usecase;

public class GetCountryUseCase
{
    private readonly ICountriesRepository _repository;

    public GetCountryUseCase(ICountriesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Country>> ExecuteGetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Country?> ExecuteGetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
