using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Seats.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Seats.Domain.Repositories;
using SistemadeTiquetess.src.modules.Seats.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Seats.Infrastructure.Repositories;

public class SeatsRepository : ISeatsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<SeatEntity> _dbSet;

    public SeatsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<SeatEntity>();
    }

    public async Task<IEnumerable<Seat>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(SeatMapper.ToDomain);
    }

    public async Task<Seat?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : SeatMapper.ToDomain(entity);
    }

    public async Task AddAsync(Seat seat)
    {
        await _dbSet.AddAsync(SeatMapper.ToEntity(seat));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Seat seat)
    {
        _dbSet.Update(SeatMapper.ToEntity(seat));
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
