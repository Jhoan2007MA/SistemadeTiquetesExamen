using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Application.Interfaces;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Countries.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Countries.Application.Services;

/// <summary>
/// Implementación concreta del servicio de negocio para los Países.
/// Realiza labores de orquestación transaccional apoyándose en 'ICountriesRepository'.
/// </summary>
public class CountriesServices : ICountriesServices
{
    private readonly ICountriesRepository _repository;

    public CountriesServices(ICountriesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Country?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Country> CreateAsync(Country country)
    {
        await _repository.AddAsync(country);
        return country;
    }

    public async Task UpdateAsync(Country country)
    {
        await _repository.UpdateAsync(country);
    }

    public async Task<Country?> GetByCodeAsync(string code)
    {
        return await _repository.GetByCodeAsync(code);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
