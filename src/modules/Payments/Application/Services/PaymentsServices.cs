using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Payments.Application.Interfaces;
using SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Payments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Payments.Application.Services;

public class PaymentsServices : IPaymentsServices
{
    private readonly IPaymentsRepository _repository;
    public PaymentsServices(IPaymentsRepository repository) => _repository = repository;

    public async Task<IEnumerable<Payment>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Payment?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<Payment> CreateAsync(Payment payment)
    {
        await _repository.AddAsync(payment);
        return payment;
    }
    public async Task UpdateAsync(Payment payment) => await _repository.UpdateAsync(payment);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
