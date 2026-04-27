using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Airlines.Application.Interfaces;
using SistemadeTiquetess.src.modules.Airlines.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Airlines.UI;

/// <summary>
/// Menú interactivo de consola para la gestión del módulo de Aerolíneas (Airlines).
/// Funciona como la capa base de presentación (UI) reemplazando al esquema de controladores web.
/// </summary>
public class AirlineMenu
{
    private readonly IAirlinesServices _services;

    public AirlineMenu(IAirlinesServices services)
    {
        _services = services;
    }

    /// <summary>
    /// Despliega el menú principal de operaciones de sub-menú para Aerolíneas.
    /// Mantiene el bucle interactivo de la consola hasta que el usuario decida salir.
    /// </summary>
    public async Task ShowMenuAsync()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("         Módulo de Aerolíneas            ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todas las aerolíneas");
            Console.WriteLine("2. Buscar aerolínea por código (ej. AV)");
            Console.WriteLine("3. Registrar nueva aerolínea");
            Console.WriteLine("4. Actualizar aerolínea existente");
            Console.WriteLine("5. Eliminar aerolínea");
            Console.WriteLine("6. Volver al menú principal");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione una opción: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListAirlinesAsync();
                    break;
                case "2":
                    await FindAirlineAsync();
                    break;
                case "3":
                    await CreateAirlineAsync();
                    break;
                case "4":
                    await UpdateAirlineAsync();
                    break;
                case "5":
                    await DeleteAirlineAsync();
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

    private async Task ListAirlinesAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Listado General de Aerolíneas ---");
        
        var airlines = await _services.GetAllAsync();
        bool hasData = false;

        foreach (var airline in airlines)
        {
            hasData = true;
            Console.WriteLine($"- ID: {airline.Id} | Código: {airline.Code} | Nombre: {airline.Name} | Activa: {(airline.IsActive ? "Sí" : "No")}");
        }

        if (!hasData)
        {
            Console.WriteLine("No se encontraron aerolíneas registradas en el sistema.");
        }

        Console.WriteLine("\nPresione cualquier tecla para regresar...");
        Console.ReadKey();
    }

    private async Task FindAirlineAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Buscar Aerolínea ---");
        Console.Write("Ingrese el código IATA/ICAO de la aerolínea (Ej: AV, LA): ");
        string? code = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(code))
        {
            // Usamos directamente la consulta por código conectada desde la BD a la UI de forma limpia
            var airline = await _services.GetByCodeAsync(code.Trim().ToUpper());
            if (airline != null)
            {
                Console.WriteLine("\n>> Datos Encontrados:");
                Console.WriteLine($"Nombre Comercial: {airline.Name}");
                Console.WriteLine($"Código Oficial: {airline.Code}");
                Console.WriteLine($"Estado Operativo: {(airline.IsActive ? "En funcionamiento" : "Dada de baja")}");
                Console.WriteLine($"Identificador Interno (GUID): {airline.Id}");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró un registro operativo bajo el código '{code}'.");
            }
        }
        else
        {
            Console.WriteLine("\nNo se ingresó un código válido para la búsqueda.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateAirlineAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Registro de Nueva Aerolínea ---");
        
        Console.Write("Nombre Comercial de la Aerolínea: ");
        string? name = Console.ReadLine();
        
        Console.Write("Código Asignado (IATA/ICAO de 2 o 3 caracteres): ");
        string? code = Console.ReadLine();
        
        try
        {
            // La entidad Aggregate 'Airline' se encarga internamente de validar sus propias invariables lógicas y longitud
            var newAirline = Airline.Create(name ?? "", code ?? "");
            await _services.CreateAsync(newAirline);
            Console.WriteLine($"\n¡Aerolínea {newAirline.Name} ({newAirline.Code}) registrada exitosamente!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError de violación a lógicas de negocio o persistencia al guardar:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task UpdateAirlineAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Modificar Aerolínea Existente ---");
        Console.Write("Por seguridad, requerimos ingresar el identificador principal (GUID / ID) a actualizar: ");
        
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("\nEl formato de ID administrado es incorrecto.");
            Console.ReadKey();
            return;
        }

        var airline = await _services.GetByIdAsync(id);
        if (airline == null)
        {
            Console.WriteLine("\nNingún registro empata con ese identificador.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\n* Presione la tecla Enter sin escribir nada en un campo si desea mantener lo actual:");

        Console.Write($"Nombre comercial actual [{airline.Name}]: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = airline.Name;

        Console.Write($"Código operacional actual [{airline.Code}]: ");
        string? code = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(code)) code = airline.Code;

        try
        {
            // Forzamos actualización segura que revalide los campos usando el Agregado Raíz
            airline.UpdateDetails(name, code);
            
            // Solicitamos a la capa de Aplicación que conecte con Repo para persistir
            await _services.UpdateAsync(airline);
            Console.WriteLine("\n¡Los datos pasados a la aerolínea fueron actualizados con éxito!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nHubo un fallo sistémico en la actualización:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task DeleteAirlineAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Definitivamente una Aerolínea ---");
        Console.Write("Atención: Ingrese el GUID asociado al registro a suprimir permanentemente: ");
        
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            try
            {
                await _services.DeleteAsync(id);
                Console.WriteLine("\nLos datos asociados se borraron sin eventualidades del repositorio físico.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError. Esto puede deberse a que dependencias están atadas lógicamente a esta entidad:\n-> {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\nEl GUID no cumple parámetros formates estándar.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
