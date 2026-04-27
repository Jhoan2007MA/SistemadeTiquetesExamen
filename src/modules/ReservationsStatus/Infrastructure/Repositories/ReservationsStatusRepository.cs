using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Repositories;
using SistemadeTiquetess.src.modules.ReservationsStatus.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.ReservationsStatus.Infrastructure.Repositories;

public class ReservationsStatusRepository : IReservationsStatusRepository
{
    private readonly DbContext _context;
    private readonly DbSet<ReservationStatusEntity> _dbSet;

    public ReservationsStatusRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<ReservationStatusEntity>();
    }

    public async Task<IEnumerable<ReservationStatus>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(ReservationStatusMapper.ToDomain);
    }

    public async Task<ReservationStatus?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : ReservationStatusMapper.ToDomain(entity);
    }

    public async Task AddAsync(ReservationStatus status)
    {
        await _dbSet.AddAsync(ReservationStatusMapper.ToEntity(status));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ReservationStatus status)
    {
        _dbSet.Update(ReservationStatusMapper.ToEntity(status));
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
