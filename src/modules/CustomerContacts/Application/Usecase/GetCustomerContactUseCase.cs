using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Application.Usecase;

public class GetCustomerContactUseCase
{
    private readonly ICustomerContactsRepository _repository;

    public GetCustomerContactUseCase(ICustomerContactsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerContact>> ExecuteGetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<CustomerContact?> ExecuteGetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }
}
