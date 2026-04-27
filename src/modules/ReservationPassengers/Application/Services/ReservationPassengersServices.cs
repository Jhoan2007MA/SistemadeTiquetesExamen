using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Application.Interfaces;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Application.Services;

public class ReservationPassengersServices : IReservationPassengersServices
{
    private readonly IReservationPassengersRepository _repository;
    public ReservationPassengersServices(IReservationPassengersRepository repository) => _repository = repository;

    public async Task<IEnumerable<ReservationPassenger>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<ReservationPassenger?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<ReservationPassenger> CreateAsync(ReservationPassenger passenger)
    {
        await _repository.AddAsync(passenger);
        return passenger;
    }
    public async Task UpdateAsync(ReservationPassenger passenger) => await _repository.UpdateAsync(passenger);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
