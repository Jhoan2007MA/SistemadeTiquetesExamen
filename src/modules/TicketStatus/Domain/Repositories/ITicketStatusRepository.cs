using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.TicketStatus.Domain.Repositories;

public interface ITicketStatusRepository
{
    Task<IEnumerable<TicketStatusAggregate>> GetAllAsync();
    Task<TicketStatusAggregate?> GetByIdAsync(Guid id);
    Task AddAsync(TicketStatusAggregate status);
    Task UpdateAsync(TicketStatusAggregate status);
    Task DeleteAsync(Guid id);
}
