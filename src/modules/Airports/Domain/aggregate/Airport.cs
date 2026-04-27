using System;

namespace SistemadeTiquetess.src.modules.Airports.Domain;

/// <summary>
/// Representa la entidad raíz (Aggregate Root) de un Aeropuerto dentro del dominio.
/// </summary>
public class Airport
{
    public Guid Id { get; private set; }
    public string IataCode { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string City { get; private set; } = string.Empty;
    public string Country { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    protected Airport() { }

    private Airport(Guid id, string iataCode, string name, string city, string country)
    {
        Id = id;
        IataCode = iataCode;
        Name = name;
        City = city;
        Country = country;
        IsActive = true;
    }

    /// <summary>
    /// Factory method para crear una nueva instancia de Airport.
    /// </summary>
    public static Airport Create(string iataCode, string name, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(iataCode))
            throw new ArgumentException("El código IATA es obligatorio.", nameof(iataCode));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del aeropuerto es obligatorio.", nameof(name));

        return new Airport(Guid.NewGuid(), iataCode, name, city, country);
    }

    /// <summary>
    /// Actualiza la información del aeropuerto.
    /// </summary>
    public void UpdateDetails(string iataCode, string name, string city, string country)
    {
        if (string.IsNullOrWhiteSpace(iataCode))
            throw new ArgumentException("El código IATA no puede estar vacío.", nameof(iataCode));
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));

        IataCode = iataCode;
        Name = name;
        City = city;
        Country = country;
    }

    public void Deactivate() => IsActive = false;
    public void Activate() => IsActive = true;
}
