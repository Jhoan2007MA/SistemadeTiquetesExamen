using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Application.Usecase;

public class CreateCustomerContactUseCase
{
    private readonly ICustomerContactsRepository _repository;

    public CreateCustomerContactUseCase(ICustomerContactsRepository repository)
    {
        _repository = repository;
    }

    public async Task<CustomerContact> ExecuteAsync(CustomerContact customerContact)
    {
        await _repository.AddAsync(customerContact);
        return customerContact;
    }
}
