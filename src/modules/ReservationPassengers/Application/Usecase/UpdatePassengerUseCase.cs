using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Application.Usecase;

public class UpdatePassengerUseCase
{
    private readonly IReservationPassengersRepository _repository;
    public UpdatePassengerUseCase(IReservationPassengersRepository repository) => _repository = repository;
    public async Task ExecuteAsync(ReservationPassenger passenger) => await _repository.UpdateAsync(passenger);
}
