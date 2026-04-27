using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Application.Interfaces;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Application.Services;

public class PaymentMethodsServices : IPaymentMethodsServices
{
    private readonly IPaymentMethodsRepository _repository;
    public PaymentMethodsServices(IPaymentMethodsRepository repository) => _repository = repository;

    public async Task<IEnumerable<PaymentMethod>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<PaymentMethod?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<PaymentMethod> CreateAsync(PaymentMethod method)
    {
        await _repository.AddAsync(method);
        return method;
    }
    public async Task UpdateAsync(PaymentMethod method) => await _repository.UpdateAsync(method);
    public async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
