using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Cities.Application.Interfaces;
using SistemadeTiquetess.src.modules.Cities.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Cities.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Cities.Application.Services;

/// <summary>
/// Implementación concreta del servicio de negocio para las Ciudades.
/// Realiza labores de orquestación transaccional apoyándose en 'ICitiesRepository'.
/// </summary>
public class CitiesServices : ICitiesServices
{
    private readonly ICitiesRepository _repository;

    public CitiesServices(ICitiesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<City?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<City> CreateAsync(City city)
    {
        await _repository.AddAsync(city);
        return city;
    }

    public async Task UpdateAsync(City city)
    {
        await _repository.UpdateAsync(city);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
