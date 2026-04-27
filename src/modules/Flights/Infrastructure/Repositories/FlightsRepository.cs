using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Flights.Domain.Repositories;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Flights.Infrastructure.Repositories;

public class FlightsRepository : IFlightsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<FlightEntity> _dbSet;

    public FlightsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<FlightEntity>();
    }

    public async Task<IEnumerable<Flight>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(FlightMapper.ToDomain);
    }

    public async Task<Flight?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : FlightMapper.ToDomain(entity);
    }

    public async Task AddAsync(Flight flight)
    {
        await _dbSet.AddAsync(FlightMapper.ToEntity(flight));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Flight flight)
    {
        _dbSet.Update(FlightMapper.ToEntity(flight));
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
