using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Repositories;
using SistemadeTiquetess.src.modules.PaymentMethods.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Infrastructure.Repositories;

public class PaymentMethodsRepository : IPaymentMethodsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<PaymentMethodEntity> _dbSet;

    public PaymentMethodsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<PaymentMethodEntity>();
    }

    public async Task<IEnumerable<PaymentMethod>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(PaymentMethodMapper.ToDomain);
    }

    public async Task<PaymentMethod?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        return entity == null ? null : PaymentMethodMapper.ToDomain(entity);
    }

    public async Task AddAsync(PaymentMethod method)
    {
        await _dbSet.AddAsync(PaymentMethodMapper.ToEntity(method));
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(PaymentMethod method)
    {
        _dbSet.Update(PaymentMethodMapper.ToEntity(method));
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
