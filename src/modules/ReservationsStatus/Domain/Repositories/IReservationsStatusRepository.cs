using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Repositories;

public interface IReservationsStatusRepository
{
    Task<IEnumerable<ReservationStatus>> GetAllAsync();
    Task<ReservationStatus?> GetByIdAsync(Guid id);
    Task AddAsync(ReservationStatus status);
    Task UpdateAsync(ReservationStatus status);
    Task DeleteAsync(Guid id);
}
