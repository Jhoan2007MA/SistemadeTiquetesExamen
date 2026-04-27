using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Reservations.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Reservations.Application.Usecase;

public class UpdateReservationUseCase
{
    private readonly IReservationsRepository _repository;
    public UpdateReservationUseCase(IReservationsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Reservation reservation) => await _repository.UpdateAsync(reservation);
}
