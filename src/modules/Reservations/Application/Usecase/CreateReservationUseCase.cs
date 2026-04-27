using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Reservations.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Reservations.Application.Usecase;

public class CreateReservationUseCase
{
    private readonly IReservationsRepository _repository;
    public CreateReservationUseCase(IReservationsRepository repository) => _repository = repository;
    public async Task<Reservation> ExecuteAsync(Reservation reservation)
    {
        await _repository.AddAsync(reservation);
        return reservation;
    }
}
