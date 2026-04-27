using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Repositories;
using SistemadeTiquetess.src.modules.CustomerContacts.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Infrastructure.Repositories;

/// <summary>
/// Implementación concreta mediante el DbContext (Entity Framework) para gestionar los Contactos de Cliente.
/// </summary>
public class CustomerContactsRepository : ICustomerContactsRepository
{
    private readonly DbContext _context;
    private readonly DbSet<CustomerContactEntity> _dbSet;

    public CustomerContactsRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<CustomerContactEntity>();
    }

    public async Task<CustomerContact?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;
        
        return CustomerContactMapper.ToDomain(entity);
    }

    public async Task<IEnumerable<CustomerContact>> GetByCustomerIdAsync(Guid customerId)
    {
        var entities = await _dbSet.Where(x => x.CustomerId == customerId).ToListAsync();
        return entities.Select(CustomerContactMapper.ToDomain);
    }

    public async Task<IEnumerable<CustomerContact>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(CustomerContactMapper.ToDomain);
    }

    public async Task AddAsync(CustomerContact customerContact)
    {
        var entity = CustomerContactMapper.ToEntity(customerContact);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(CustomerContact customerContact)
    {
        var entity = CustomerContactMapper.ToEntity(customerContact);
        _dbSet.Update(entity);
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
