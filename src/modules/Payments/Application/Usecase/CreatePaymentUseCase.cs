using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Payments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Payments.Application.Usecase;

public class CreatePaymentUseCase
{
    private readonly IPaymentsRepository _repository;
    public CreatePaymentUseCase(IPaymentsRepository repository) => _repository = repository;
    public async Task<Payment> ExecuteAsync(Payment payment)
    {
        await _repository.AddAsync(payment);
        return payment;
    }
}
