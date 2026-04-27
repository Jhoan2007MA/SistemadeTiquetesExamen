using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Infrastructure.Entity;

public static class PaymentMethodMapper
{
    public static PaymentMethodEntity ToEntity(PaymentMethod aggregate)
    {
        return new PaymentMethodEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name
        };
    }

    public static PaymentMethod ToDomain(PaymentMethodEntity entity)
    {
        var aggregate = (PaymentMethod)Activator.CreateInstance(typeof(PaymentMethod), nonPublic: true)!;
        typeof(PaymentMethod).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(PaymentMethod).GetProperty("Name")?.SetValue(aggregate, entity.Name);
        return aggregate;
    }
}
