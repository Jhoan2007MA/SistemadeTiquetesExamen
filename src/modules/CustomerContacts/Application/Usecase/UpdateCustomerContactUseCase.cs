using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Application.Usecase;

public class UpdateCustomerContactUseCase
{
    private readonly ICustomerContactsRepository _repository;

    public UpdateCustomerContactUseCase(ICustomerContactsRepository repository)
    {
        _repository = repository;
    }

    public async Task ExecuteAsync(CustomerContact customerContact)
    {
        await _repository.UpdateAsync(customerContact);
    }
}
