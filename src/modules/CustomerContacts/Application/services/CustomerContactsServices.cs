using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Application.Interfaces;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Application.Services;

/// <summary>
/// Implementación concreta del servicio de negocio para los Contactos del Cliente.
/// Realiza labores de orquestación transaccional apoyándose en 'ICustomerContactsRepository'.
/// </summary>
public class CustomerContactsServices : ICustomerContactsServices
{
    private readonly ICustomerContactsRepository _repository;

    public CustomerContactsServices(ICustomerContactsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<CustomerContact>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<CustomerContact?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<CustomerContact> CreateAsync(CustomerContact customerContact)
    {
        await _repository.AddAsync(customerContact);
        return customerContact;
    }

    public async Task UpdateAsync(CustomerContact customerContact)
    {
        await _repository.UpdateAsync(customerContact);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
