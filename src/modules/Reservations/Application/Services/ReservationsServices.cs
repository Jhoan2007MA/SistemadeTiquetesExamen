using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Reservations.Application.Interfaces;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Reservations.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Reservations.Application.Services;

public class ReservationsServices : IReservationsServices
{
    private readonly IReservationsRepository _repository;
    public ReservationsServices(IReservationsRepository repository) => _repository = repository;

    public async Task<IEnumerable<Reservation>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Reservation?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        await _repository.AddAsync(reservation);
        return reservation;
    }
    public async Task UpdateAsync(Reservation reservation) => await _repository.UpdateAsync(reservation);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
