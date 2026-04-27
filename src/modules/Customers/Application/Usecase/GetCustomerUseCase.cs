using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Customers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Customers.Application.Usecase;

public class GetCustomerUseCase
{
    private readonly ICustomersRepository _repository;

    public GetCustomerUseCase(ICustomersRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Customer>> ExecuteGetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer?> ExecuteGetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
