using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Seats.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Seats.Application.Interfaces;

public interface ISeatsServices
{
    Task<IEnumerable<Seat>> GetAllAsync();
    Task<Seat?> GetByIdAsync(Guid id);
    Task<Seat> CreateAsync(Seat seat);
    Task UpdateAsync(Seat seat);
    Task DeleteAsync(Guid id);
}
