using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Infrastructure.Entity;

/// <summary>
/// Clase responsable de convertir entre el modelo anémico de BD (CustomerContactEntity) y el Agregado de Dominio (CustomerContact).
/// Permite re-hidratar el Agregado Raíz omitiendo los validadores pero sin exponer "setters" públicos incontrolados.
/// </summary>
public static class CustomerContactMapper
{
    public static CustomerContactEntity ToEntity(CustomerContact aggregate)
    {
        return new CustomerContactEntity
        {
            Id = aggregate.Id,
            CustomerId = aggregate.CustomerId,
            Email = aggregate.Email,
            PhoneNumber = aggregate.PhoneNumber,
            IsActive = aggregate.IsActive
        };
    }

    public static CustomerContact ToDomain(CustomerContactEntity entity)
    {
        // Reconstruimos el Aggregate Root utilizando la instancia protegida sin pasar por una nueva creación manual
        var aggregate = (CustomerContact)Activator.CreateInstance(typeof(CustomerContact), nonPublic: true)!;
         
        // Asignación explícita saltando encapsulación física usando Reflection
        typeof(CustomerContact).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(CustomerContact).GetProperty("CustomerId")?.SetValue(aggregate, entity.CustomerId);
        typeof(CustomerContact).GetProperty("Email")?.SetValue(aggregate, entity.Email);
        typeof(CustomerContact).GetProperty("PhoneNumber")?.SetValue(aggregate, entity.PhoneNumber);
        typeof(CustomerContact).GetProperty("IsActive")?.SetValue(aggregate, entity.IsActive);
         
        return aggregate;
    }
}
