using System;

namespace SistemadeTiquetess.src.modules.Seats.Domain.Aggregate;

public class Seat
{
    public Guid Id { get; private set; }
    public string SeatNumber { get; private set; } = string.Empty;
    public string Row { get; private set; } = string.Empty;
    public string Class { get; private set; } = string.Empty; // Economica, Ejecutiva, etc.

    protected Seat() { }

    private Seat(Guid id, string seatNumber, string row, string seatClass)
    {
        Id = id;
        SeatNumber = seatNumber;
        Row = row;
        Class = seatClass;
    }

    public static Seat Create(string seatNumber, string row, string seatClass)
    {
        if (string.IsNullOrWhiteSpace(seatNumber)) throw new ArgumentException("Número de asiento requerido.");
        return new Seat(Guid.NewGuid(), seatNumber.Trim(), row.Trim(), seatClass.Trim());
    }

    public void UpdateDetails(string seatNumber, string row, string seatClass)
    {
        SeatNumber = seatNumber.Trim();
        Row = row.Trim();
        Class = seatClass.Trim();
    }
}
