using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Aircrafts.infrastructure.Entity;

/// <summary>
/// Clase responsable de convertir entre el modelo anémico de BD (AircraftEntity) y el Agregado de Dominio (Aircraft).
/// Utiliza Reflection al hidratar el dominio para respetar los 'private set' y no "contaminar" la clase de negocio.
/// </summary>
public static class AircraftMapper
{
    public static AircraftEntity ToEntity(Aircraft aggregate)
    {
        return new AircraftEntity
        {
            Id = aggregate.Id,
            RegistrationNumber = aggregate.RegistrationNumber,
            Model = aggregate.Model,
            Capacity = aggregate.Capacity,
            Manufacturer = aggregate.Manufacturer,
            IsActive = aggregate.IsActive
        };
    }

    public static Aircraft ToDomain(AircraftEntity entity)
    {
        // Reconstruimos el Aggregate Root utilizando instancia privada sin pasar por la factoría (ya que proviene de un registro existente de BD válido).
        var aggregate = (Aircraft)Activator.CreateInstance(typeof(Aircraft), nonPublic: true)!;
         
        // Asignamos las propiedades privadas
        typeof(Aircraft).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Aircraft).GetProperty("RegistrationNumber")?.SetValue(aggregate, entity.RegistrationNumber);
        typeof(Aircraft).GetProperty("Model")?.SetValue(aggregate, entity.Model);
        typeof(Aircraft).GetProperty("Capacity")?.SetValue(aggregate, entity.Capacity);
        typeof(Aircraft).GetProperty("Manufacturer")?.SetValue(aggregate, entity.Manufacturer);
        typeof(Aircraft).GetProperty("IsActive")?.SetValue(aggregate, entity.IsActive);
         
        return aggregate;
    }
}
