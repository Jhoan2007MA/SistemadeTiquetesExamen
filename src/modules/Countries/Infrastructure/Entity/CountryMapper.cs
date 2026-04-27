using System;
using System.Reflection;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Countries.Infrastructure.Entity;

/// <summary>
/// Clase responsable de convertir entre el modelo anémico de BD (CountryEntity) y el Agregado de Dominio (Country).
/// Se encarga de hacer el bypass necesario sin romper la protección del Agregado Raíz.
/// </summary>
public static class CountryMapper
{
    public static CountryEntity ToEntity(Country aggregate)
    {
        return new CountryEntity
        {
            Id = aggregate.Id,
            Name = aggregate.Name,
            Code = aggregate.Code,
            IsActive = aggregate.IsActive
        };
    }

    public static Country ToDomain(CountryEntity entity)
    {
        // Reconstruimos el Aggregate Root utilizando la instancia protegida sin pasar por una nueva creación
        var aggregate = (Country)Activator.CreateInstance(typeof(Country), nonPublic: true)!;
         
        // Set usando Reflection para omitir que las propiedades sean solo privadas ('private set')
        typeof(Country).GetProperty("Id")?.SetValue(aggregate, entity.Id);
        typeof(Country).GetProperty("Name")?.SetValue(aggregate, entity.Name);
        typeof(Country).GetProperty("Code")?.SetValue(aggregate, entity.Code);
        typeof(Country).GetProperty("IsActive")?.SetValue(aggregate, entity.IsActive);
         
        return aggregate;
    }
}
