using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Application.Usecase;

public class DeletePaymentMethodUseCase
{
    private readonly IPaymentMethodsRepository _repository;
    public DeletePaymentMethodUseCase(IPaymentMethodsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Guid id) => await _repository.DeleteAsync(id);
}
