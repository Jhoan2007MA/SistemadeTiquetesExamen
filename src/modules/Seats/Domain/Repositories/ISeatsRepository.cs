using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Seats.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Seats.Domain.Repositories;

public interface ISeatsRepository
{
    Task<IEnumerable<Seat>> GetAllAsync();
    Task<Seat?> GetByIdAsync(Guid id);
    Task AddAsync(Seat seat);
    Task UpdateAsync(Seat seat);
    Task DeleteAsync(Guid id);
}
