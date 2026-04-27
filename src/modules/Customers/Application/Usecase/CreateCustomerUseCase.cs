using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Customers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Customers.Application.Usecase;

public class CreateCustomerUseCase
{
    private readonly ICustomersRepository _repository;

    public CreateCustomerUseCase(ICustomersRepository repository)
    {
        _repository = repository;
    }

    public async Task<Customer> ExecuteAsync(Customer customer)
    {
        await _repository.AddAsync(customer);
        return customer;
    }
}
