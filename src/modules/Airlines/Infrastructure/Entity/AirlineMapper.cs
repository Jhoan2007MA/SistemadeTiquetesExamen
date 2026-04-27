using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Airlines.infrastructure.Entity;

/// <summary>
/// Clase responsable de convertir entre el modelo anémico de BD (AirlineEntity) y el Agregado de Dominio (Airline).
/// Se encarga de hacer el "bypass" necesario sin romper la protección del Agregado Raíz.
/// </summary>
public static class AirlineMapper
{
    public static AirlineEntity ToEntity(Airline aggregate)
    {
        return new AirlineEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name,
            Code = aggregate.Code,
            IsActive = aggregate.IsActive
        };
    }

    public static Airline ToDomain(AirlineEntity entity)
    {
        // Reconstruimos el Aggregate Root utilizando la instancia protegida sin pasar por una nueva creación
        var aggregate = (Airline)Activator.CreateInstance(typeof(Airline), nonPublic: true)!;
         
        // Set usando Reflection para omitir que las propiedades sean solo privadas ('private set')
        typeof(Airline).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Airline).GetProperty("Name")?.SetValue(aggregate, entity.Name);
        typeof(Airline).GetProperty("Code")?.SetValue(aggregate, entity.Code);
        typeof(Airline).GetProperty("IsActive")?.SetValue(aggregate, entity.IsActive);
         
        return aggregate;
    }
}
