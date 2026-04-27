using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Application.Usecase;

public class DeletePassengerUseCase
{
    private readonly IReservationPassengersRepository _repository;
    public DeletePassengerUseCase(IReservationPassengersRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Guid id) => await _repository.DeleteAsync(id);
}
