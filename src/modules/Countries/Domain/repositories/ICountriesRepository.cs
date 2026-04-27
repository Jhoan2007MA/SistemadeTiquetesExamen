using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Countries.Domain.Repositories;

/// <summary>
/// Contrato del Repositorio de base de datos para los Países.
/// Desvincula la lógica de negocio técnica de las tecnologías de persistencia subyacentes.
/// </summary>
public interface ICountriesRepository
{
    Task<Country?> GetByIdAsync(Guid id);
    
    // Búsqueda orientada directamente por el formato de código ISO (ej. CO, US, ES)
    Task<Country?> GetByCodeAsync(string code);
    
    Task<IEnumerable<Country>> GetAllAsync();
    
    // Útil para prevenir colisiones en la creación
    Task<bool> ExistsByCodeAsync(string code);
    
    Task AddAsync(Country country);
    
    Task UpdateAsync(Country country);
    
    Task DeleteAsync(Guid id);
}
