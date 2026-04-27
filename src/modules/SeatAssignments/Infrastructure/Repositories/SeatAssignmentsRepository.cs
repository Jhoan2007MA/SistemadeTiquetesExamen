using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Repositories;
using SistemadeTiquetess.src.modules.SeatAssignments.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.SeatAssignments.Infrastructure.Repositories;

public class SeatAssignmentsRepository : ISeatAssignmentsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<SeatAssignmentEntity> _dbSet;

    public SeatAssignmentsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<SeatAssignmentEntity>();
    }

    public async Task<IEnumerable<SeatAssignment>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(SeatAssignmentMapper.ToDomain);
    }

    public async Task<SeatAssignment?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : SeatAssignmentMapper.ToDomain(entity);
    }

    public async Task AddAsync(SeatAssignment assignment)
    {
        await _dbSet.AddAsync(SeatAssignmentMapper.ToEntity(assignment));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(SeatAssignment assignment)
    {
        _dbSet.Update(SeatAssignmentMapper.ToEntity(assignment));
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
