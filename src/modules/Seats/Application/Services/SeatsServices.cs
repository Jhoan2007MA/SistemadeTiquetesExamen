using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Seats.Application.Interfaces;
using SistemadeTiquetess.src.modules.Seats.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Seats.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Seats.Application.Services;

public class SeatsServices : ISeatsServices
{
    private readonly ISeatsRepository _repository;
    public SeatsServices(ISeatsRepository repository) => _repository = repository;

    public async Task<IEnumerable<Seat>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Seat?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<Seat> CreateAsync(Seat seat)
    {
        await _repository.AddAsync(seat);
        return seat;
    }
    public async Task UpdateAsync(Seat seat) => await _repository.UpdateAsync(seat);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
