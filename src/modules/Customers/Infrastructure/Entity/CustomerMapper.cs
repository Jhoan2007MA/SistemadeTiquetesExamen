using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Customers.Infrastructure.Entity;

/// <summary>
/// Clase estática responsable de convertir bidireccionalmente entre el modelo anémico de BD (CustomerEntity) 
/// y el Agregado de Dominio (Customer). Permite la hidratación del 'Aggregate Root'.
/// </summary>
public static class CustomerMapper
{
    public static CustomerEntity ToEntity(Customer aggregate)
    {
        return new CustomerEntity
        {
            Id = aggregate.Id,
            FullName = aggregate.FullName,
            DocumentNumber = aggregate.DocumentNumber,
            IsActive = aggregate.IsActive
        };
    }

    public static Customer ToDomain(CustomerEntity entity)
    {
        // Reconstruimos el Aggregate Root utilizando la instancia protegida a través de Reflection
        var aggregate = (Customer)Activator.CreateInstance(typeof(Customer), nonPublic: true)!;
         
        // Set usando Reflection para omitir 'private set' y rellenar las propiedades desde la base de datos
        typeof(Customer).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Customer).GetProperty("FullName")?.SetValue(aggregate, entity.FullName);
        typeof(Customer).GetProperty("DocumentNumber")?.SetValue(aggregate, entity.DocumentNumber);
        typeof(Customer).GetProperty("IsActive")?.SetValue(aggregate, entity.IsActive);
         
        return aggregate;
    }
}
