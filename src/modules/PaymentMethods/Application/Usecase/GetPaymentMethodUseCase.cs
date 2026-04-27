using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Application.Usecase;

public class GetPaymentMethodUseCase
{
    private readonly IPaymentMethodsRepository _repository;
    public GetPaymentMethodUseCase(IPaymentMethodsRepository repository) => _repository = repository;
    public async Task<IEnumerable<PaymentMethod>> ExecuteGetAllAsync() => await _repository.GetAllAsync();
    public async Task<PaymentMethod?> ExecuteGetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
}
