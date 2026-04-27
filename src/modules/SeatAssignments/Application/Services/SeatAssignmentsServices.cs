using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAssignments.Application.Interfaces;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.SeatAssignments.Application.Services;

public class SeatAssignmentsServices : ISeatAssignmentsServices
{
    private readonly ISeatAssignmentsRepository _repository;
    public SeatAssignmentsServices(ISeatAssignmentsRepository repository) => _repository = repository;

    public async Task<IEnumerable<SeatAssignment>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<SeatAssignment?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<SeatAssignment> CreateAsync(SeatAssignment assignment)
    {
        await _repository.AddAsync(assignment);
        return assignment;
    }
    public async Task UpdateAsync(SeatAssignment assignment) => await _repository.UpdateAsync(assignment);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
