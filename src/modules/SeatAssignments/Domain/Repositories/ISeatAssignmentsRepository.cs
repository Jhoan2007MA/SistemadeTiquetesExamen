using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAssignments.Domain.Repositories;

public interface ISeatAssignmentsRepository
{
    Task<IEnumerable<SeatAssignment>> GetAllAsync();
    Task<SeatAssignment?> GetByIdAsync(Guid id);
    Task AddAsync(SeatAssignment assignment);
    Task UpdateAsync(SeatAssignment assignment);
    Task DeleteAsync(Guid id);
}
