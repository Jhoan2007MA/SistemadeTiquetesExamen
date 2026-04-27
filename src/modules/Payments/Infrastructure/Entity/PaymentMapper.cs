using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Payments.Infrastructure.Entity;

public static class PaymentMapper
{
    public static PaymentEntity ToEntity(Payment aggregate)
    {
        return new PaymentEntity
        {
            Id = aggregate.Id,
            ReservationId = aggregate.ReservationId,
            PaymentMethodId = aggregate.PaymentMethodId,
            Amount = aggregate.Amount,
            PaymentDate = aggregate.PaymentDate
        };
    }

    public static Payment ToDomain(PaymentEntity entity)
    {
        var aggregate = (Payment)Activator.CreateInstance(typeof(Payment), nonPublic: true)!;
        typeof(Payment).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Payment).GetProperty("ReservationId")?.SetValue(aggregate, entity.ReservationId);
        typeof(Payment).GetProperty("PaymentMethodId")?.SetValue(aggregate, entity.PaymentMethodId);
        typeof(Payment).GetProperty("Amount")?.SetValue(aggregate, entity.Amount);
        typeof(Payment).GetProperty("PaymentDate")?.SetValue(aggregate, entity.PaymentDate);
        return aggregate;
    }
}
