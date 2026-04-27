using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Payments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Payments.Application.Usecase;

public class GetPaymentUseCase
{
    private readonly IPaymentsRepository _repository;
    public GetPaymentUseCase(IPaymentsRepository repository) => _repository = repository;
    public async Task<IEnumerable<Payment>> ExecuteGetAllAsync() => await _repository.GetAllAsync();
    public async Task<Payment?> ExecuteGetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
}
