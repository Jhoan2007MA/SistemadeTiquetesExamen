using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Airports.Domain.Repositories;
using SistemadeTiquetess.src.modules.Airports.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Airports.Infrastructure.Repositories;

/// <summary>
/// Implementación concreta del repositorio de Aeropuertos utilizando Entity Framework Core.
/// </summary>
public class AirportsRepository : IAirportsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<AirportEntity> _dbSet;

    public AirportsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<AirportEntity>();
    }

    public async Task<Airport?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;
        
        return AirportMapper.ToDomain(entity);
    }

    public async Task<Airport?> GetByIataCodeAsync(string iataCode)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.IataCode == iataCode);
        if (entity == null) return null;
        
        return AirportMapper.ToDomain(entity);
    }

    public async Task<IEnumerable<Airport>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(AirportMapper.ToDomain);
    }

    public async Task AddAsync(Airport airport)
    {
        var entity = AirportMapper.ToEntity(airport);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Airport airport)
    {
        var entity = AirportMapper.ToEntity(airport);
        
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
