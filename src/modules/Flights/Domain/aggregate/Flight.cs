using System;

namespace SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;

public class Flight
{
    public Guid Id { get; private set; }
    public string FlightNumber { get; private set; } = string.Empty;
    public Guid StatusId { get; private set; }

    protected Flight() { }

    private Flight(Guid id, string flightNumber, Guid statusId)
    {
        Id = id;
        FlightNumber = flightNumber;
        StatusId = statusId;
    }

    public static Flight Create(string flightNumber, Guid statusId)
    {
        if (string.IsNullOrWhiteSpace(flightNumber))
            throw new ArgumentException("El número de vuelo es requerido.");
        
        return new Flight(Guid.NewGuid(), flightNumber.Trim().ToUpper(), statusId);
    }

    public void UpdateDetails(string flightNumber, Guid statusId)
    {
        if (string.IsNullOrWhiteSpace(flightNumber))
            throw new ArgumentException("El número de vuelo no puede estar vacío.");
        
        FlightNumber = flightNumber.Trim().ToUpper();
        StatusId = statusId;
    }
}
