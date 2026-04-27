using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Application.Usecase;

public class CreatePassengerUseCase
{
    private readonly IReservationPassengersRepository _repository;
    public CreatePassengerUseCase(IReservationPassengersRepository repository) => _repository = repository;
    public async Task<ReservationPassenger> ExecuteAsync(ReservationPassenger passenger)
    {
        await _repository.AddAsync(passenger);
        return passenger;
    }
}
