using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.ReservationsStatus.Application.Interfaces;

public interface IReservationsStatusServices
{
    Task<IEnumerable<ReservationStatus>> GetAllAsync();
    Task<ReservationStatus?> GetByIdAsync(Guid id);
    Task<ReservationStatus> CreateAsync(ReservationStatus status);
    Task UpdateAsync(ReservationStatus status);
    Task DeleteAsync(Guid id);
}
