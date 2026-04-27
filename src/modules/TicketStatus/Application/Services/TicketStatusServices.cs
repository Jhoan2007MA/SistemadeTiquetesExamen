using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.TicketStatus.Application.Interfaces;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.TicketStatus.Application.Services;

public class TicketStatusServices : ITicketStatusServices
{
    private readonly ITicketStatusRepository _repository;
    public TicketStatusServices(ITicketStatusRepository repository) => _repository = repository;

    public async Task<IEnumerable<TicketStatusAggregate>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<TicketStatusAggregate?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<TicketStatusAggregate> CreateAsync(TicketStatusAggregate status)
    {
        await _repository.AddAsync(status);
        return status;
    }
    public async Task UpdateAsync(TicketStatusAggregate status) => await _repository.UpdateAsync(status);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
