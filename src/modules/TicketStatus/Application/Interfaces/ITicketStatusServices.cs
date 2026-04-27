using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.TicketStatus.Application.Interfaces;

public interface ITicketStatusServices
{
    Task<IEnumerable<TicketStatusAggregate>> GetAllAsync();
    Task<TicketStatusAggregate?> GetByIdAsync(Guid id);
    Task<TicketStatusAggregate> CreateAsync(TicketStatusAggregate status);
    Task UpdateAsync(TicketStatusAggregate status);
    Task DeleteAsync(Guid id);
}
