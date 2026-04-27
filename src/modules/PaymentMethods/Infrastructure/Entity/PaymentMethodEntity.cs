using System;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Infrastructure.Entity;

public class PaymentMethodEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
