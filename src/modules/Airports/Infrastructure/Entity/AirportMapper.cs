using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Airports.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Airports.Infrastructure.Entity;

/// <summary>
/// Clase estática encargada de mapear entre la entidad de infraestructura y el agregado de dominio.
/// </summary>
public static class AirportMapper
{
    public static Airport ToDomain(AirportEntity entity)
    {
        // Utilizamos reflexión para crear la instancia debido a que el constructor de dominio es privado
        var airport = (Airport)Activator.CreateInstance(typeof(Airport), nonPublic: true)!;
        
        typeof(Airport).GetProperty(nameof(Airport.Id))?.SetValue(airport, entity.Id);
        typeof(Airport).GetProperty(nameof(Airport.IataCode))?.SetValue(airport, entity.IataCode);
        typeof(Airport).GetProperty(nameof(Airport.Name))?.SetValue(airport, entity.Name);
        typeof(Airport).GetProperty(nameof(Airport.City))?.SetValue(airport, entity.City);
        typeof(Airport).GetProperty(nameof(Airport.Country))?.SetValue(airport, entity.Country);
        typeof(Airport).GetProperty(nameof(Airport.IsActive))?.SetValue(airport, entity.IsActive);
        
        return airport;
    }

    public static AirportEntity ToEntity(Airport domain)
    {
        return new AirportEntity
        {
            Id = domain.Id,
            IataCode = domain.IataCode,
            Name = domain.Name,
            City = domain.City,
            Country = domain.Country,
            IsActive = domain.IsActive
        };
    }
}
