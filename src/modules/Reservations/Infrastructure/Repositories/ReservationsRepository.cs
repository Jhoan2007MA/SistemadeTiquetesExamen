using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Reservations.Domain.Repositories;
using SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Reservations.Infrastructure.Repositories;

public class ReservationsRepository : IReservationsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<ReservationEntity> _dbSet;

    public ReservationsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<ReservationEntity>();
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(ReservationMapper.ToDomain);
    }

    public async Task<Reservation?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : ReservationMapper.ToDomain(entity);
    }

    public async Task AddAsync(Reservation reservation)
    {
        await _dbSet.AddAsync(ReservationMapper.ToEntity(reservation));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Reservation reservation)
    {
        _dbSet.Update(ReservationMapper.ToEntity(reservation));
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
