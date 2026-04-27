using System;

namespace SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;

public class Payment
{
    public Guid Id { get; private set; }
    public Guid ReservationId { get; private set; }
    public Guid PaymentMethodId { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime PaymentDate { get; private set; }

    protected Payment() { }

    private Payment(Guid id, Guid reservationId, Guid methodId, decimal amount, DateTime date)
    {
        Id = id;
        ReservationId = reservationId;
        PaymentMethodId = methodId;
        Amount = amount;
        PaymentDate = date;
    }

    public static Payment Create(Guid reservationId, Guid methodId, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("El monto del pago debe ser mayor a cero.");

        return new Payment(Guid.NewGuid(), reservationId, methodId, amount, DateTime.UtcNow);
    }

    public void UpdateDetails(Guid methodId, decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("El monto debe ser mayor a cero.");

        PaymentMethodId = methodId;
        Amount = amount;
    }
}
