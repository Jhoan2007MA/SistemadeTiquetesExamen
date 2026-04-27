using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Payments.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Payments.Application.Usecase;

public class UpdatePaymentUseCase
{
    private readonly IPaymentsRepository _repository;
    public UpdatePaymentUseCase(IPaymentsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(Payment payment) => await _repository.UpdateAsync(payment);
}
