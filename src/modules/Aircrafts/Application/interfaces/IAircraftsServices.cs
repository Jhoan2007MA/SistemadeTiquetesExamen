using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Aircrafts.Application.Interfaces;

public interface IAircraftsServices
{
    Task<IEnumerable<Aircraft>> GetAllAsync();
    Task<Aircraft?> GetByIdAsync(Guid id);
    Task<Aircraft> CreateAsync(Aircraft aircraft);
    Task UpdateAsync(Aircraft aircraft);
    Task DeleteAsync(Guid id);
}
