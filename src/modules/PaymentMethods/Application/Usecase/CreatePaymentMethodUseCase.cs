using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Application.Usecase;

public class CreatePaymentMethodUseCase
{
    private readonly IPaymentMethodsRepository _repository;
    public CreatePaymentMethodUseCase(IPaymentMethodsRepository repository) => _repository = repository;
    public async Task<PaymentMethod> ExecuteAsync(PaymentMethod method)
    {
        await _repository.AddAsync(method);
        return method;
    }
}
