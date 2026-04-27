using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationsStatus.Application.Interfaces;
using SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Aggregate;
using SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.ReservationsStatus.Application.Services;

public class ReservationsStatusServices : IReservationsStatusServices
{
    private readonly IReservationsStatusRepository _repository;
    public ReservationsStatusServices(IReservationsStatusRepository repository) => _repository = repository;

    public async Task<IEnumerable<ReservationStatus>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<ReservationStatus?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<ReservationStatus> CreateAsync(ReservationStatus status)
    {
        await _repository.AddAsync(status);
        return status;
    }
    public async Task UpdateAsync(ReservationStatus status) => await _repository.UpdateAsync(status);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
