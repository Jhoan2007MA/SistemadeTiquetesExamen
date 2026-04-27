using System;

namespace SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;

/// <summary>
/// Entidad raíz (Aggregate Root) que representa a un País (Country) dentro del sistema.
/// Preserva sus propios invariantes de manera encapsulada.
/// </summary>
public class Country
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    // Constructor sin parámetros para ORMs
    protected Country() { }

    private Country(Guid id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
        IsActive = true; // Por defecto nace de alta en el sistema
    }

    /// <summary>
    /// Crea formalmente en el dominio un nuevo País.
    /// </summary>
    public static Country Create(string name, string code)
    {
        // Aplicamos validaciones de negocio básicas
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre del país es requerido.");
            
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("El código ISO del país es un requisito.");

        return new Country(Guid.NewGuid(), name.Trim(), code.Trim().ToUpper());
    }

    /// <summary>
    /// Cambia simultáneamente los datos descriptivos del país garantizando consistencia.
    /// </summary>
    public void UpdateDetails(string name, string code)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("No se puede proveer un nombre vacío al actualizar.");
            
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("No se puede proveer un código nulo o vacío al actualizar.");

        Name = name.Trim();
        Code = code.Trim().ToUpper();
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
