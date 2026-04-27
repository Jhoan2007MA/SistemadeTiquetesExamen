using System;

namespace SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;

/// <summary>
/// Entidad raíz (Aggregate Root) que representa un Contacto de Cliente dentro del sistema.
/// Preserva sus propios invariantes de manera encapsulada.
/// </summary>
public class CustomerContact
{
    public Guid Id { get; private set; }
    public Guid CustomerId { get; private set; } // Vinculación eventual con módulo de Customers
    public string Email { get; private set; } = string.Empty;
    public string PhoneNumber { get; private set; } = string.Empty;
    public bool IsActive { get; private set; }

    // Constructor sin parámetros para ORMs
    protected CustomerContact() { }

    private CustomerContact(Guid id, Guid customerId, string email, string phoneNumber)
    {
        Id = id;
        CustomerId = customerId;
        Email = email;
        PhoneNumber = phoneNumber;
        IsActive = true; 
    }

    /// <summary>
    /// Crea formalmente en el dominio un nuevo contacto.
    /// </summary>
    public static CustomerContact Create(Guid customerId, string email, string phoneNumber)
    {
        if (customerId == Guid.Empty)
            throw new ArgumentException("El ID del cliente es requerido.");

        if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("Se debe suministrar al menos un correo electrónico o un número de teléfono.");

        return new CustomerContact(
            Guid.NewGuid(), 
            customerId, 
            email?.Trim() ?? string.Empty, 
            phoneNumber?.Trim() ?? string.Empty
        );
    }

    /// <summary>
    /// Cambia los datos de contacto del cliente garantizando consistencia.
    /// </summary>
    public void UpdateDetails(string email, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(email) && string.IsNullOrWhiteSpace(phoneNumber))
            throw new ArgumentException("No se pueden dejar ambos campos (correo y teléfono) vacíos al actualizar.");

        Email = email?.Trim() ?? string.Empty;
        PhoneNumber = phoneNumber?.Trim() ?? string.Empty;
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
