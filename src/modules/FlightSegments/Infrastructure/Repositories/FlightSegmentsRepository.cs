using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Repositories;
using SistemadeTiquetess.src.modules.FlightSegments.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.FlightSegments.Infrastructure.Repositories;

public class FlightSegmentsRepository : IFlightSegmentsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<SegmentEntity> _dbSet;

    public FlightSegmentsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<SegmentEntity>();
    }

    public async Task<IEnumerable<FlightSegment>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(SegmentMapper.ToDomain);
    }

    public async Task<FlightSegment?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : SegmentMapper.ToDomain(entity);
    }

    public async Task AddAsync(FlightSegment segment)
    {
        await _dbSet.AddAsync(SegmentMapper.ToEntity(segment));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FlightSegment segment)
    {
        _dbSet.Update(SegmentMapper.ToEntity(segment));
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
