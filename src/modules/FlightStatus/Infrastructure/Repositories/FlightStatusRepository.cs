using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightStatus.Domain.Repositories;
using SistemadeTiquetess.src.modules.FlightStatus.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.FlightStatus.Infrastructure.Repositories;

public class FlightStatusRepository : IFlightStatusRepository
{
    private readonly DbContext _context;
    private readonly DbSet<StatusEntity> _dbSet;

    public FlightStatusRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<StatusEntity>();
    }

    public async Task<IEnumerable<FlightStatusAggregate>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(StatusMapper.ToDomain);
    }

    public async Task<FlightStatusAggregate?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : StatusMapper.ToDomain(entity);
    }

    public async Task AddAsync(FlightStatusAggregate status)
    {
        await _dbSet.AddAsync(StatusMapper.ToEntity(status));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FlightStatusAggregate status)
    {
        _dbSet.Update(StatusMapper.ToEntity(status));
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
