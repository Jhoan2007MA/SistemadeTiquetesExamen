using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Application.Usecase;

public class UpdatePaymentMethodUseCase
{
    private readonly IPaymentMethodsRepository _repository;
    public UpdatePaymentMethodUseCase(IPaymentMethodsRepository repository) => _repository = repository;
    public async Task ExecuteAsync(PaymentMethod method) => await _repository.UpdateAsync(method);
}
