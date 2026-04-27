using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAssignments.Application.Interfaces;

public interface ISeatAssignmentsServices
{
    Task<IEnumerable<SeatAssignment>> GetAllAsync();
    Task<SeatAssignment?> GetByIdAsync(Guid id);
    Task<SeatAssignment> CreateAsync(SeatAssignment assignment);
    Task UpdateAsync(SeatAssignment assignment);
    Task DeleteAsync(Guid id);
}
