using System;

namespace SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;

public class Flight
{
    public Guid Id { get; private set; }
    public string FlightNumber { get; private set; } = string.Empty;
    public Guid StatusId { get; private set; }
    public string Origin { get; private set; } = string.Empty;
    public string Destination { get; private set; } = string.Empty;
    public DateTime DepartureDate { get; private set; }

    protected Flight() { }

    private Flight(Guid id, string flightNumber, Guid statusId, string origin, string destination, DateTime departureDate)
    {
        Id = id;
        FlightNumber = flightNumber;
        StatusId = statusId;
        Origin = origin;
        Destination = destination;
        DepartureDate = departureDate;
    }

    public static Flight Create(string flightNumber, Guid statusId, string origin, string destination, DateTime departureDate)
    {
        if (string.IsNullOrWhiteSpace(flightNumber))
            throw new ArgumentException("El número de vuelo es requerido.");
        if (string.IsNullOrWhiteSpace(origin))
            throw new ArgumentException("El origen es requerido.");
        if (string.IsNullOrWhiteSpace(destination))
            throw new ArgumentException("El destino es requerido.");
        
        return new Flight(Guid.NewGuid(), flightNumber.Trim().ToUpper(), statusId, origin.Trim().ToUpper(), destination.Trim().ToUpper(), departureDate);
    }

    public void UpdateDetails(string flightNumber, Guid statusId, string origin, string destination, DateTime departureDate)
    {
        if (string.IsNullOrWhiteSpace(flightNumber))
            throw new ArgumentException("El número de vuelo no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(origin))
            throw new ArgumentException("El origen no puede estar vacío.");
        if (string.IsNullOrWhiteSpace(destination))
            throw new ArgumentException("El destino no puede estar vacío.");
        
        FlightNumber = flightNumber.Trim().ToUpper();
        StatusId = statusId;
        Origin = origin.Trim().ToUpper();
        Destination = destination.Trim().ToUpper();
        DepartureDate = departureDate;
    }
}
