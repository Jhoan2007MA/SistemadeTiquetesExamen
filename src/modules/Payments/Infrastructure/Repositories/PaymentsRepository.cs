using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Payments.Domain.Repositories;
using SistemadeTiquetess.src.modules.Payments.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Payments.Infrastructure.Repositories;

public class PaymentsRepository : IPaymentsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<PaymentEntity> _dbSet;

    public PaymentsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<PaymentEntity>();
    }

    public async Task<IEnumerable<Payment>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(PaymentMapper.ToDomain);
    }

    public async Task<Payment?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : PaymentMapper.ToDomain(entity);
    }

    public async Task AddAsync(Payment payment)
    {
        await _dbSet.AddAsync(PaymentMapper.ToEntity(payment));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Payment payment)
    {
        _dbSet.Update(PaymentMapper.ToEntity(payment));
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
