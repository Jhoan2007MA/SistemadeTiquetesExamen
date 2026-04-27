using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Application.Usecase;

public class DeleteCustomerContactUseCase
{
    private readonly ICustomerContactsRepository _repository;

    public DeleteCustomerContactUseCase(ICustomerContactsRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
