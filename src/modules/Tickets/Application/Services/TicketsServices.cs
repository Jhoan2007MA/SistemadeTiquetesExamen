using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Tickets.Application.Interfaces;
using SistemadeTiquetess.src.modules.Tickets.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Tickets.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Tickets.Application.Services;

public class TicketsServices : ITicketsServices
{
    private readonly ITicketsRepository _repository;
    public TicketsServices(ITicketsRepository repository) => _repository = repository;

    public async Task<IEnumerable<Ticket>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Ticket?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<Ticket> CreateAsync(Ticket ticket)
    {
        await _repository.AddAsync(ticket);
        return ticket;
    }
    public async Task UpdateAsync(Ticket ticket) => await _repository.UpdateAsync(ticket);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
