using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Application.Interfaces;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Customers.Domain.Repositories;

namespace SistemadeTiquetess.src.modules.Customers.Application.Services;

/// <summary>
/// Implementación concreta del servicio de negocio principal para los Clientes.
/// Realiza labores de orquestación transaccional apoyándose unívocamente en 'ICustomersRepository'.
/// </summary>
public class CustomersServices : ICustomersServices
{
    private readonly ICustomersRepository _repository;

    public CustomersServices(ICustomersRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task<Customer> CreateAsync(Customer customer)
    {
        await _repository.AddAsync(customer);
        return customer;
    }

    public async Task UpdateAsync(Customer customer)
    {
        // En aplicaciones más robustas aquí se pueden añadir chequeos cruzados de duplicación antes de guardar
        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
