using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.CustomerContacts.Application.Interfaces;
using SistemadeTiquetess.src.modules.CustomerContacts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.CustomerContacts.UI;

/// <summary>
/// Menú interactivo de consola para la gestión del módulo de Contactos del Cliente (CustomerContacts).
/// Funciona como la capa base de presentación (UI) interactuando directamente con Application Services.
/// </summary>
public class CustomerContactsMenu
{
    private readonly ICustomerContactsServices _services;

    public CustomerContactsMenu(ICustomerContactsServices services)
    {
        _services = services;
    }

    /// <summary>
    /// Despliega el menú principal de operaciones interactivas para los Contactos.
    /// Mantiene el bucle interactivo de la consola hasta que el usuario decida salir.
    /// </summary>
    public async Task ShowMenuAsync()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("      Módulo de Contactos del Cliente    ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los contactos generales");
            Console.WriteLine("2. Buscar contacto por ID del Contacto");
            Console.WriteLine("3. Registrar nuevo medio de contacto");
            Console.WriteLine("4. Actualizar contacto existente");
            Console.WriteLine("5. Eliminar contacto (borrado físico)");
            Console.WriteLine("6. Volver al menú principal");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione una opción: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListContactsAsync();
                    break;
                case "2":
                    await FindContactByIdAsync();
                    break;
                case "3":
                    await CreateContactAsync();
                    break;
                case "4":
                    await UpdateContactAsync();
                    break;
                case "5":
                    await DeleteContactAsync();
                    break;
                case "6":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private async Task ListContactsAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Listado General de Medios de Contacto ---");
        
        var contacts = await _services.GetAllAsync();
        bool hasData = false;

        foreach (var contact in contacts)
        {
            hasData = true;
            Console.WriteLine($"- ID: {contact.Id} | ClienteID: {contact.CustomerId} | Correo: {contact.Email} | Teléfono: {contact.PhoneNumber} | Activo: {(contact.IsActive ? "Sí" : "No")}");
        }

        if (!hasData)
        {
            Console.WriteLine("No se encontraron contactos registrados en el sistema.");
        }

        Console.WriteLine("\nPresione cualquier tecla para regresar...");
        Console.ReadKey();
    }

    private async Task FindContactByIdAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Buscar Contacto de Cliente ---");
        Console.Write("Ingrese el ID único (GUID) del Registro de Contacto: ");
        
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            var contact = await _services.GetByIdAsync(id);
            if (contact != null)
            {
                Console.WriteLine("\n>> Datos Encontrados:");
                Console.WriteLine($"Propietario (Cliente ID): {contact.CustomerId}");
                Console.WriteLine($"Correo Electrónico: {contact.Email}");
                Console.WriteLine($"Número Telefónico: {contact.PhoneNumber}");
                Console.WriteLine($"Estado Operativo: {(contact.IsActive ? "Activo" : "Dado de baja")}");
                Console.WriteLine($"ID Único del Registro (GUID): {contact.Id}");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró ningún contacto asociado al identificador provisto.");
            }
        }
        else
        {
            Console.WriteLine("\nEl GUID ingresado no es válido.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateContactAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Registro de Nuevo Contacto ---");
        
        Console.Write("ID Único del Cliente asociado (GUID): ");
        if (!Guid.TryParse(Console.ReadLine(), out Guid customerId))
        {
            Console.WriteLine("\nFormato de ID de cliente no válido. Se abortará el proceso.");
            Console.ReadKey();
            return;
        }

        Console.Write("Correo Electrónico (opcional si se provee teléfono): ");
        string? email = Console.ReadLine();
        
        Console.Write("Teléfono Móvil/Fijo (opcional si se provee correo): ");
        string? phone = Console.ReadLine();
        
        try
        {
            // Validaciones se resuelven nativamente en el Aggregate Root 'CustomerContact'
            var newContact = CustomerContact.Create(customerId, email ?? "", phone ?? "");
            await _services.CreateAsync(newContact);
            Console.WriteLine($"\n¡El medio de contacto para el cliente '{newContact.CustomerId}' ha sido registrado excelentemente!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError de violación a reglas comerciales o problema al guardar:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task UpdateContactAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Modificar Información de Contacto Existente ---");
        Console.Write("Ingrese el GUID exacto del registro de Contacto a sobreescribir: ");
        
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("\nEl formato del ID es inválido.");
            Console.ReadKey();
            return;
        }

        var contact = await _services.GetByIdAsync(id);
        if (contact == null)
        {
            Console.WriteLine("\nNo se encontró una vía de contacto asimilada a ese ID.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\n* Presione la tecla 'Enter' sin escribir nada si desea mantener el dato actual:");

        Console.Write($"Correo actual registrado [{contact.Email}]: ");
        string? email = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(email)) email = contact.Email;

        Console.Write($"Teléfono actual registrado [{contact.PhoneNumber}]: ");
        string? phone = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(phone)) phone = contact.PhoneNumber;

        try
        {
            // Forzamos actualización segura que revalide los campos a través del Agregado
            contact.UpdateDetails(email, phone);
            
            // Solicitamos a la capa Application que realice el update en el DB Set
            await _services.UpdateAsync(contact);
            Console.WriteLine("\n¡Los datos de contacto fueron reemplazados correctamente de la base de datos!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nFalló en la actualización transaccional:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task DeleteContactAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Permanentemente una Vía de Contacto ---");
        Console.Write("Advertencia: Al ingresar el GUID de contacto el registro será borrado. Ingrese GUID: ");
        
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            try
            {
                await _services.DeleteAsync(id);
                Console.WriteLine("\nLos registros de metadata asociados a este contacto se borraron definitivamente de la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError al ejecutar la acción DELETE. Posible dependencia del motor:\n-> {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\nEl formato del ID GUID no es procesable.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
