using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Tickets.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Tickets.Domain.Repositories;
using SistemadeTiquetess.src.modules.Tickets.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Tickets.Infrastructure.Repositories;

public class TicketsRepository : ITicketsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<TicketEntity> _dbSet;

    public TicketsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TicketEntity>();
    }

    public async Task<IEnumerable<Ticket>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(TicketMapper.ToDomain);
    }

    public async Task<Ticket?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : TicketMapper.ToDomain(entity);
    }

    public async Task AddAsync(Ticket ticket)
    {
        await _dbSet.AddAsync(TicketMapper.ToEntity(ticket));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _dbSet.Update(TicketMapper.ToEntity(ticket));
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
