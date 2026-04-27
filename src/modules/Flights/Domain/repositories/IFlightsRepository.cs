using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Flights.Domain.Repositories;

public interface IFlightsRepository
{
    Task<IEnumerable<Flight>> GetAllAsync();
    Task<Flight?> GetByIdAsync(Guid id);
    Task AddAsync(Flight flight);
    Task UpdateAsync(Flight flight);
    Task DeleteAsync(Guid id);
}
