using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Reservations.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Reservations.Application.Usecase;

public class DeleteReservationUseCase
{
    private readonly IReservationsRepository _repository;
    public DeleteReservationUseCase(IReservationsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Guid id) => await _repository.DeleteAsync(id);
}
