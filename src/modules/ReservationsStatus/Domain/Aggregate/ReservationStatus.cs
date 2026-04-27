using System;

namespace SistemadeTiquetess.src.modules.ReservationsStatus.Domain.Aggregate;

public class ReservationStatus
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    protected ReservationStatus() { }

    private ReservationStatus(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static ReservationStatus Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del estado es requerido.");
        return new ReservationStatus(Guid.NewGuid(), name.Trim());
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre no puede estar vacío.");
        Name = name.Trim();
    }
}
