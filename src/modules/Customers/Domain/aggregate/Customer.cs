using System;

namespace SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;

/// <summary>
/// Entidad raíz (Aggregate Root) que representa a un Cliente dentro del sistema.
/// Preserva sus invariantes logicas (ej. obligatoriedad de nombre y documento).
/// </summary>
public class Customer
{
    public Guid Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string DocumentNumber { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    // Constructor sin parámetros para ORMs
    protected Customer() { }

    private Customer(Guid id, string fullName, string documentNumber)
    {
        Id = id;
        FullName = fullName;
        DocumentNumber = documentNumber;
        IsActive = true; 
    }

    /// <summary>
    /// Crea formalmente en el dominio un nuevo Cliente.
    /// </summary>
    public static Customer Create(string fullName, string documentNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("El nombre completo del cliente es un requisito obligatorio.");

        if (string.IsNullOrWhiteSpace(documentNumber))
            throw new ArgumentException("El documento de identidad es un parámetro requerido.");

        return new Customer(
            Guid.NewGuid(), 
            fullName.Trim(), 
            documentNumber.Trim()
        );
    }

    /// <summary>
    /// Cambia los datos descriptivos del cliente garantizando consistencia y reglas lógicas.
    /// </summary>
    public void UpdateDetails(string fullName, string documentNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
            throw new ArgumentException("El nombre no puede dejarse en blanco o nulo al actualizar.");

        if (string.IsNullOrWhiteSpace(documentNumber))
            throw new ArgumentException("Se debe proveer un número de documento al actualizar.");

        FullName = fullName.Trim();
        DocumentNumber = documentNumber.Trim();
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
