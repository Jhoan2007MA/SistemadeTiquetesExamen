using System;
using SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;
using SistemadeTiquetess.src.modules.PaymentMethods.Infrastructure.Entity;

namespace SistemadeTiquetess.src.modules.Payments.Infrastructure.Entity;

public class PaymentEntity
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid PaymentMethodId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    // Propiedades de navegación
    public virtual ReservationEntity Reservation { get; set; } = null!;
    public virtual PaymentMethodEntity PaymentMethod { get; set; } = null!;
}
