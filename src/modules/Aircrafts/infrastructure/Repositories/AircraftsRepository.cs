using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Repositories;
using SistemadeTiquetess.src.modules.Aircrafts.infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Aircrafts.infrastructure.Repositories;

/// <summary>
/// Implementación concreta del repositorio de Aeronaves utilizando Entity Framework Core.
/// </summary>
public class AircraftsRepository : IAircraftsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<AircraftEntity> _dbSet;

    public AircraftsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<AircraftEntity>();
    }

    public async Task<Aircraft?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;
        
        return AircraftMapper.ToDomain(entity);
    }

    public async Task<Aircraft?> GetByRegistrationNumberAsync(string registrationNumber)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.RegistrationNumber == registrationNumber);
        if (entity == null) return null;
        
        return AircraftMapper.ToDomain(entity);
    }

    public async Task<IEnumerable<Aircraft>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(AircraftMapper.ToDomain);
    }

    public async Task<bool> ExistsByRegistrationAsync(string registrationNumber)
    {
        return await _dbSet.AnyAsync(x => x.RegistrationNumber == registrationNumber);
    }

    public async Task AddAsync(Aircraft aircraft)
    {
        var entity = AircraftMapper.ToEntity(aircraft);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Aircraft aircraft)
    {
        var entity = AircraftMapper.ToEntity(aircraft);
        
        // Adjuntamos y actualizamos
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
