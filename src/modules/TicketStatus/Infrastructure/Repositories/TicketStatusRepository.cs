using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Repositories;
using SistemadeTiquetess.src.modules.TicketStatus.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.TicketStatus.Infrastructure.Repositories;

public class TicketStatusRepository : ITicketStatusRepository
{
    private readonly DbContext _context;
    private readonly DbSet<TicketStatusEntity> _dbSet;

    public TicketStatusRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TicketStatusEntity>();
    }

    public async Task<IEnumerable<TicketStatusAggregate>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(TicketStatusMapper.ToDomain);
    }

    public async Task<TicketStatusAggregate?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : TicketStatusMapper.ToDomain(entity);
    }

    public async Task AddAsync(TicketStatusAggregate status)
    {
        await _dbSet.AddAsync(TicketStatusMapper.ToEntity(status));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TicketStatusAggregate status)
    {
        _dbSet.Update(TicketStatusMapper.ToEntity(status));
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
