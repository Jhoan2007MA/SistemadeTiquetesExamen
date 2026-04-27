using System;

namespace SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;

/// <summary>
/// Entidad raíz (Aggregate Root) que representa a una Aerolínea dentro del sistema.
/// Preserva sus propios invariantes de manera encapsulada.
/// </summary>
public class Airline
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Code { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    // Constructor sin parámetros para ORMs
    protected Airline() { }

    private Airline(Guid id, string name, string code)
    {
        Id = id;
        Name = name;
        Code = code;
        IsActive = true; // Por defecto nace de alta en el sistema
    }

    /// <summary>
    /// Crea formalmente en el dominio una nueva Aerolínea.
    /// </summary>
    public static Airline Create(string name, string code)
    {
        // Aplicamos validaciones de negocio básicas
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("El nombre comercial de la aerolínea es requerido.");
            
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("El código (ej. IATA/ICAO) de operaciones es un requisito.");

        return new Airline(Guid.NewGuid(), name.Trim(), code.Trim().ToUpper());
    }

    /// <summary>
    /// Cambia simultáneamente los datos descriptivos de la aerolínea garantizando consistencia.
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
