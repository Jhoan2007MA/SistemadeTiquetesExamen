using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Airlines.Domain.Repositories;

/// <summary>
/// Contrato del Repositorio de base de datos para la Aerolínea.
/// Desvincula la lógica de negocio técnica de las tecnologías de persistencia subyacentes.
/// </summary>
public interface IAirlinesRepository
{
    Task<Airline?> GetByIdAsync(Guid id);
    
    // Búsqueda orientada directamente por el formato de código como AVIANCA (AV), LATAM (LA)
    Task<Airline?> GetByCodeAsync(string code);
    
    Task<IEnumerable<Airline>> GetAllAsync();
    
    // Útil para prevenir colisiones en la creación
    Task<bool> ExistsByCodeAsync(string code);
    
    Task AddAsync(Airline airline);
    
    Task UpdateAsync(Airline airline);
    
    Task DeleteAsync(Guid id);
}
