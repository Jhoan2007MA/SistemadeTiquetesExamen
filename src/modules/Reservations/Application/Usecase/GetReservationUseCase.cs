using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Reservations.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Reservations.Application.Usecase;

public class GetReservationUseCase
{
    private readonly IReservationsRepository _repository;
    public GetReservationUseCase(IReservationsRepository repository) => _repository = repository;
    public async Task<IEnumerable<Reservation>> ExecuteGetAllAsync() => await _repository.GetAllAsync();
    public async Task<Reservation?> ExecuteGetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
}
