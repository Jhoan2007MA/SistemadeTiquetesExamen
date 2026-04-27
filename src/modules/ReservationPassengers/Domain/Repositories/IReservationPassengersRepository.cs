using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Repositories;

public interface IReservationPassengersRepository
{
    Task<IEnumerable<ReservationPassenger>> GetAllAsync();
    Task<ReservationPassenger?> GetByIdAsync(Guid id);
    Task AddAsync(ReservationPassenger passenger);
    Task UpdateAsync(ReservationPassenger passenger);
    Task DeleteAsync(Guid id);
}
