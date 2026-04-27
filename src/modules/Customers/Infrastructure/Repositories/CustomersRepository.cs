using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Customers.Domain.Repositories;
using SistemadeTiquetess.src.modules.Customers.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Customers.Infrastructure.Repositories;

/// <summary>
/// Implementación asíncrona concreta mediante el DbContext (Entity Framework) para gestionar Clientes.
/// </summary>
public class CustomersRepository : ICustomersRepository
{
    private readonly DbContext _context;
    private readonly DbSet<CustomerEntity> _dbSet;

    public CustomersRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<CustomerEntity>();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;
        
        return CustomerMapper.ToDomain(entity);
    }

    public async Task<Customer?> GetByDocumentNumberAsync(string documentNumber)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.DocumentNumber == documentNumber);
        if (entity == null) return null;
        
        return CustomerMapper.ToDomain(entity);
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(CustomerMapper.ToDomain);
    }

    public async Task AddAsync(Customer customer)
    {
        var entity = CustomerMapper.ToEntity(customer);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Customer customer)
    {
        var entity = CustomerMapper.ToEntity(customer);
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
