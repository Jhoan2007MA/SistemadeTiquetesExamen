using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Application.Usecase;

public class GetPassengerUseCase
{
    private readonly IReservationPassengersRepository _repository;
    public GetPassengerUseCase(IReservationPassengersRepository repository) => _repository = repository;
    public async Task<IEnumerable<ReservationPassenger>> ExecuteGetAllAsync() => await _repository.GetAllAsync();
    public async Task<ReservationPassenger?> ExecuteGetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
}
