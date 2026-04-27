using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Customers.Application.Interfaces;
using SistemadeTiquetess.src.modules.Customers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Customers.UI;

/// <summary>
/// Menú interactivo de consola para la gestión del módulo de Clientes (Customers).
/// Funciona como la capa base de presentación (UI) interactuando directamente con Application Services.
/// </summary>
public class CustomersMenu
{
    private readonly ICustomersServices _services;

    public CustomersMenu(ICustomersServices services)
    {
        _services = services;
    }

    /// <summary>
    /// Despliega el menú principal interactivo de operaciones para los Clientes.
    /// Mantiene el bucle interactivo de la consola hasta que el usuario decida salir.
    /// </summary>
    public async Task ShowMenuAsync()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("           Módulo de Clientes            ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los clientes");
            Console.WriteLine("2. Buscar cliente por Documento de Identidad");
            Console.WriteLine("3. Registrar nuevo cliente");
            Console.WriteLine("4. Actualizar cliente existente");
            Console.WriteLine("5. Eliminar cliente (borrado físico)");
            Console.WriteLine("6. Volver al menú principal");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione una opción: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListCustomersAsync();
                    break;
                case "2":
                    await FindCustomerByDocumentAsync();
                    break;
                case "3":
                    await CreateCustomerAsync();
                    break;
                case "4":
                    await UpdateCustomerAsync();
                    break;
                case "5":
                    await DeleteCustomerAsync();
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

    private async Task ListCustomersAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Listado General de Clientes ---");
        
        var customers = await _services.GetAllAsync();
        bool hasData = false;

        foreach (var customer in customers)
        {
            hasData = true;
            Console.WriteLine($"- ID: {customer.Id} | Doc: {customer.DocumentNumber} | Nombre: {customer.FullName} | Activo: {(customer.IsActive ? "Sí" : "No")}");
        }

        if (!hasData)
        {
            Console.WriteLine("No se encontraron clientes registrados en el sistema.");
        }

        Console.WriteLine("\nPresione cualquier tecla para regresar...");
        Console.ReadKey();
    }

    private async Task FindCustomerByDocumentAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Buscar Cliente ---");
        Console.Write("Ingrese el Número de Documento (ID/CC/Pasaporte): ");
        string? document = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(document))
        {
            // Usando GetByIdAsync no funcionará para documento, por lo tanto requerimos que el repositorio
            // se comunique directamente si tenemos el método o recuperamos todo y filtramos.
            // Para mantener el rendimiento se asume que usas el método `GetByDocumentNumberAsync` 
            // incrustado en el ICustomersServices o aquí se itera.
            // En caso que ICustomersServices no lo tenga explícito, filtramos la memoria (simulación UI ideal):
            // Nota: Para sistemas muy grandes, esto debe vivir explícito en el ICustomersServices también.
            var allCustomers = await _services.GetAllAsync();
            var customer = System.Linq.Enumerable.FirstOrDefault(allCustomers, x => x.DocumentNumber == document.Trim());

            if (customer != null)
            {
                Console.WriteLine("\n>> Datos Encontrados:");
                Console.WriteLine($"Nombre Completo: {customer.FullName}");
                Console.WriteLine($"Documento Identidad: {customer.DocumentNumber}");
                Console.WriteLine($"Estado: {(customer.IsActive ? "Activo" : "Inactivo")}");
                Console.WriteLine($"ID Único (GUID): {customer.Id}");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró un cliente asociado al documento '{document}'.");
            }
        }
        else
        {
            Console.WriteLine("\nBúsqueda cancelada, formato vacío.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateCustomerAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Registro de Nuevo Cliente ---");
        
        Console.Write("Nombre Completo (Obligatorio): ");
        string? name = Console.ReadLine();
        
        Console.Write("Documento de Identidad (ej: DNI, CC, Pasaporte): ");
        string? document = Console.ReadLine();
        
        try
        {
            var newCustomer = Customer.Create(name ?? "", document ?? "");
            await _services.CreateAsync(newCustomer);
            Console.WriteLine($"\n¡El cliente {newCustomer.FullName} ha sido ingresado al sistema con éxito!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError de violación a lógicas o falla en guardado:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task UpdateCustomerAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Modificar Cliente Existente ---");
        Console.Write("Ingrese el identificador principal (GUID) del cliente a actualizar: ");
        
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("\nEl GUID provisto es estructuralmente inválido.");
            Console.ReadKey();
            return;
        }

        var customer = await _services.GetByIdAsync(id);
        if (customer == null)
        {
            Console.WriteLine("\nNo se encontró correlación de ese GUID con ningún cliente.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\n* Presione la tecla 'Enter' sin escribir nada en un campo si desea que conserve el valor actual:");

        Console.Write($"Nombre Completo actual [{customer.FullName}]: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = customer.FullName;

        Console.Write($"Documento actual [{customer.DocumentNumber}]: ");
        string? document = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(document)) document = customer.DocumentNumber;

        try
        {
            // Forzamos actualización segura usando el Aggregate Root 
            customer.UpdateDetails(name, document);
            
            // Enviamos el objeto alterado a Application Service
            await _services.UpdateAsync(customer);
            Console.WriteLine("\n¡Los datos del cliente fueron refactorizados sin errores!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHubo un problema actualizando el cliente:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task DeleteCustomerAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Definitivamente un Cliente ---");
        Console.Write("Atención: Ingrese el GUID exacto del cliente que será borrado para siempre: ");
        
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            try
            {
                await _services.DeleteAsync(id);
                Console.WriteLine("\nEl cliente fue borrado del repositorio sin interrupciones.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nFallo crítico. Posiblemente el cliente tenga contactos o dependencias atadas:\n-> {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\nEl formato del ID asociado es erróneo.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
