using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Application.Interfaces;

public interface IReservationPassengersServices
{
    Task<IEnumerable<ReservationPassenger>> GetAllAsync();
    Task<ReservationPassenger?> GetByIdAsync(Guid id);
    Task<ReservationPassenger> CreateAsync(ReservationPassenger passenger);
    Task UpdateAsync(ReservationPassenger passenger);
    Task DeleteAsync(Guid id);
}
