using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airlines.Domain.Repositories;
using SistemadeTiquetess.src.modules.Airlines.infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Airlines.infrastructure.Repositories;

/// <summary>
/// Implementación concreta mediante el DbContext (Entity Framework) para gestionar aerolíneas.
/// </summary>
public class AirlinesRepository : IAirlinesRepository
{
    // Se utiliza el DbContext del sistema
    private readonly DbContext _context;
    private readonly DbSet<AirlineEntity> _dbSet;

    public AirlinesRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<AirlineEntity>();
    }

    public async Task<Airline?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;
        
        return AirlineMapper.ToDomain(entity);
    }

    public async Task<Airline?> GetByCodeAsync(string code)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Code == code);
        if (entity == null) return null;
        
        return AirlineMapper.ToDomain(entity);
    }

    public async Task<IEnumerable<Airline>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(AirlineMapper.ToDomain);
    }

    public async Task<bool> ExistsByCodeAsync(string code)
    {
        return await _dbSet.AnyAsync(x => x.Code == code);
    }

    public async Task AddAsync(Airline airline)
    {
        var entity = AirlineMapper.ToEntity(airline);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Airline airline)
    {
        var entity = AirlineMapper.ToEntity(airline);
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
