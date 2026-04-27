using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Payments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Payments.Application.Usecase;

public class DeletePaymentUseCase
{
    private readonly IPaymentsRepository _repository;
    public DeletePaymentUseCase(IPaymentsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Guid id) => await _repository.DeleteAsync(id);
}
