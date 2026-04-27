using System;

namespace SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;

public class PaymentMethod
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    protected PaymentMethod() { }

    private PaymentMethod(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static PaymentMethod Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del método de pago es requerido.");

        return new PaymentMethod(Guid.NewGuid(), name.Trim());
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del método de pago no puede estar vacío.");

        Name = name.Trim();
    }
}
