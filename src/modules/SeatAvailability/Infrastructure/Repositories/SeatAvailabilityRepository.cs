using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Aggregate;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Repositories;
using SistemadeTiquetess.src.modules.SeatAvailability.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.SeatAvailability.Infrastructure.Repositories;

public class SeatAvailabilityRepository : ISeatAvailabilityRepository
{
    private readonly DbContext _context;
    private readonly DbSet<SeatAvailabilityEntity> _dbSet;

    public SeatAvailabilityRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<SeatAvailabilityEntity>();
    }

    public async Task<IEnumerable<SeatAvailabilityAggregate>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(SeatAvailabilityMapper.ToDomain);
    }

    public async Task<SeatAvailabilityAggregate?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : SeatAvailabilityMapper.ToDomain(entity);
    }

    public async Task AddAsync(SeatAvailabilityAggregate availability)
    {
        await _dbSet.AddAsync(SeatAvailabilityMapper.ToEntity(availability));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SeatAvailabilityAggregate availability)
    {
        _dbSet.Update(SeatAvailabilityMapper.ToEntity(availability));
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
