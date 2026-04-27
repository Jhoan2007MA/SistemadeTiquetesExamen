using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Repositories;
using SistemadeTiquetess.src.modules.ReservationPassengers.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Infrastructure.Repositories;

public class ReservationPassengersRepository : IReservationPassengersRepository
{
    private readonly DbContext _context;
    private readonly DbSet<ReservationPassengerEntity> _dbSet;

    public ReservationPassengersRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<ReservationPassengerEntity>();
    }

    public async Task<IEnumerable<ReservationPassenger>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(ReservationPassengerMapper.ToDomain);
    }

    public async Task<ReservationPassenger?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : ReservationPassengerMapper.ToDomain(entity);
    }

    public async Task AddAsync(ReservationPassenger passenger)
    {
        await _dbSet.AddAsync(ReservationPassengerMapper.ToEntity(passenger));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(ReservationPassenger passenger)
    {
        _dbSet.Update(ReservationPassengerMapper.ToEntity(passenger));
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
