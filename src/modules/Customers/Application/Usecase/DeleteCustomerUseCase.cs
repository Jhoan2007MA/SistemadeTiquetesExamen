using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Customers.Application.Usecase;

public class DeleteCustomerUseCase
{
    private readonly ICustomersRepository _repository;

    public DeleteCustomerUseCase(ICustomersRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
