using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Countries.Domain.Repositories;
using SistemadeTiquetess.src.modules.Countries.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Countries.Infrastructure.Repositories;

/// <summary>
/// Implementación concreta mediante el DbContext (Entity Framework) para gestionar países.
/// </summary>
public class CountriesRepository : ICountriesRepository
{
    // Se utiliza el DbContext del sistema
    private readonly DbContext _context;
    private readonly DbSet<CountryEntity> _dbSet;

    public CountriesRepository(DbContext context)
    {
        _context = context;
        _dbSet = _context.Set<CountryEntity>();
    }

    public async Task<Country?> GetByIdAsync(Guid id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return null;
        
        return CountryMapper.ToDomain(entity);
    }

    public async Task<Country?> GetByCodeAsync(string code)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(x => x.Code == code);
        if (entity == null) return null;
        
        return CountryMapper.ToDomain(entity);
    }

    public async Task<IEnumerable<Country>> GetAllAsync()
    {
        var entities = await _dbSet.ToListAsync();
        return entities.Select(CountryMapper.ToDomain);
    }

    public async Task<bool> ExistsByCodeAsync(string code)
    {
        return await _dbSet.AnyAsync(x => x.Code == code);
    }

    public async Task AddAsync(Country country)
    {
        var entity = CountryMapper.ToEntity(country);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Country country)
    {
        var entity = CountryMapper.ToEntity(country);
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
