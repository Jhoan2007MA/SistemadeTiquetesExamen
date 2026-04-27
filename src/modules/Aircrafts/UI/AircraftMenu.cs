using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Aircrafts.Application.Interfaces;
using SistemadeTiquetess.src.modules.Aircrafts.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Aircrafts.UI;

/// <summary>
/// Menú interactivo de consola para la gestión de Aeronaves (Aircrafts).
/// Actúa como la capa de Presentación (UI) en este módulo.
/// </summary>
public class AircraftMenu
{
    private readonly IAircraftsServices _services;

    public AircraftMenu(IAircraftsServices services)
    {
        _services = services;
    }

    /// <summary>
    /// Muestra el menú principal de Aeronaves y gestiona el bucle de opciones.
    /// </summary>
    public async Task ShowMenuAsync()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("    Módulo de Aeronaves (Aircrafts)      ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todas las aeronaves");
            Console.WriteLine("2. Buscar aeronave por ID");
            Console.WriteLine("3. Registrar nueva aeronave");
            Console.WriteLine("4. Actualizar aeronave");
            Console.WriteLine("5. Eliminar aeronave");
            Console.WriteLine("6. Volver al menú principal");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione una opción: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListAircraftsAsync();
                    break;
                case "2":
                    await FindAircraftAsync();
                    break;
                case "3":
                    await CreateAircraftAsync();
                    break;
                case "4":
                    await UpdateAircraftAsync();
                    break;
                case "5":
                    await DeleteAircraftAsync();
                    break;
                case "6":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Presione cualquier tecla para intentar nuevamente.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private async Task ListAircraftsAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Listado de Aeronaves ---");
        
        var aircrafts = await _services.GetAllAsync();
        bool hasData = false;

        foreach (var aircraft in aircrafts)
        {
            hasData = true;
            Console.WriteLine($"- ID: {aircraft.Id} | Matrícula: {aircraft.RegistrationNumber} | Modelo: {aircraft.Model} | Capacidad: {aircraft.Capacity} pasajeros | Activo: {(aircraft.IsActive ? "Sí" : "No")}");
        }

        if (!hasData)
        {
            Console.WriteLine("No hay aeronaves registradas actualmente.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task FindAircraftAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Buscar Aeronave ---");
        Console.Write("Ingrese el identificador (ID / Guid) de la aeronave: ");
        
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            var aircraft = await _services.GetByIdAsync(id);
            if (aircraft != null)
            {
                Console.WriteLine("\n>> Datos de la Aeronave:");
                Console.WriteLine($"Matrícula: {aircraft.RegistrationNumber}");
                Console.WriteLine($"Modelo: {aircraft.Model}");
                Console.WriteLine($"Fabricante: {aircraft.Manufacturer}");
                Console.WriteLine($"Capacidad: {aircraft.Capacity} pasajeros");
                Console.WriteLine($"Estado: {(aircraft.IsActive ? "Operativa (Activa)" : "Inactiva")}");
            }
            else
            {
                Console.WriteLine("\nNo se encontró ninguna aeronave que coincida con ese ID en el sistema.");
            }
        }
        else
        {
            Console.WriteLine("\nFormato introducido no válido. Se requiere un formato Guid tipo (XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX).");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateAircraftAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Registrar Nueva Aeronave ---");
        
        Console.Write("Matrícula (ej. HK-123): ");
        string? registration = Console.ReadLine();
        
        Console.Write("Modelo (ej. Boeing 737): ");
        string? model = Console.ReadLine();
        
        Console.Write("Fabricante (ej. Boeing): ");
        string? manufacturer = Console.ReadLine();
        
        Console.Write("Capacidad (max. pasajeros): ");
        if (!int.TryParse(Console.ReadLine(), out int capacity))
        {
            Console.WriteLine("\nError: La capacidad debe ser un valor numérico válido.");
            Console.ReadKey();
            return;
        }

        try
        {
            // La entidad Aggregate raíz "Aircraft" se encargará de validar las reglas de negocio al crear
            var newAircraft = Aircraft.Create(registration ?? "", model ?? "", capacity, manufacturer ?? "");
            await _services.CreateAsync(newAircraft);
            Console.WriteLine($"\n¡Aeronave {registration} registrada con éxito dentro del sistema!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n>> Se produjo un error por regla de negocio o persistencia:\n{ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task UpdateAircraftAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Actualizar Aeronave ---");
        Console.Write("Ingrese el identificador (ID) de la aeronave que desea editar: ");
        
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("\nFormato de ID inválido.");
            Console.ReadKey();
            return;
        }

        var aircraft = await _services.GetByIdAsync(id);
        if (aircraft == null)
        {
            Console.WriteLine("\nNo se encontró ninguna aeronave con ese ID.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\n(Presione Enter si desea mantener el valor actual)");

        Console.Write($"Matrícula actual [{aircraft.RegistrationNumber}]: ");
        string? registration = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(registration)) registration = aircraft.RegistrationNumber;

        Console.Write($"Modelo actual [{aircraft.Model}]: ");
        string? model = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(model)) model = aircraft.Model;
        
        Console.Write($"Fabricante actual [{aircraft.Manufacturer}]: ");
        string? manufacturer = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(manufacturer)) manufacturer = aircraft.Manufacturer;

        Console.Write($"Capacidad actual [{aircraft.Capacity}]: ");
        string? capacityStr = Console.ReadLine();
        int capacity = aircraft.Capacity;
        if (!string.IsNullOrWhiteSpace(capacityStr))
        {
            int.TryParse(capacityStr, out capacity);
        }

        try
        {
            // Ejecutamos validación directamente en la entidad
            aircraft.UpdateDetails(registration, model, capacity, manufacturer);
            
            // Persistimos los cambios
            await _services.UpdateAsync(aircraft);
            Console.WriteLine("\nDatos de la aeronave actualizados en el sistema con éxito.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError al actualizar: {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task DeleteAircraftAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Aeronave ---");
        Console.Write("Ingrese el identificador (ID) de la aeronave a eliminar: ");
        
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            try
            {
                // NOTA: Para un borrado lógico (Soft Delete), deberías llamar al servicio de Desactivar
                // Aquí estamos usando el Delete de la base de datos según lo implementado en el Repositorio.
                await _services.DeleteAsync(id);
                Console.WriteLine("\nLa aeronave fue eliminada satisfactoriamente (si existía).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nNo se pudo eliminar por restricción de negocio o BD: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\nEl formato del ID que ingresaste es inválido.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
