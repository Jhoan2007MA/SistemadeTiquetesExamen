using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Customers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Customers.Application.Usecase;

public class UpdateCustomerUseCase
{
    private readonly ICustomersRepository _repository;

    public UpdateCustomerUseCase(ICustomersRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Customer customer)
    {
        await _repository.UpdateAsync(customer);
    }
}
