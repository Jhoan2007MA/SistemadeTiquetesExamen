using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Countries.Application.Interfaces;
using SistemadeTiquetess.src.modules.Countries.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Countries.UI;

/// <summary>
/// Menú interactivo de consola para la gestión del módulo de Países (Countries).
/// Funciona como la capa base de presentación (UI) interactuando directamente con Application Services.
/// </summary>
public class CountriesMenu
{
    private readonly ICountriesServices _services;

    public CountriesMenu(ICountriesServices services)
    {
        _services = services;
    }

    /// <summary>
    /// Despliega el menú principal de operaciones interactivas para Países.
    /// Mantiene el bucle interactivo de la consola hasta que el usuario decida salir.
    /// </summary>
    public async Task ShowMenuAsync()
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("           Módulo de Países              ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los países");
            Console.WriteLine("2. Buscar país por código ISO (ej. CO, US)");
            Console.WriteLine("3. Registrar nuevo país");
            Console.WriteLine("4. Actualizar país existente");
            Console.WriteLine("5. Eliminar país (borrado físico)");
            Console.WriteLine("6. Volver al menú principal");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione una opción: ");

            string? option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListCountriesAsync();
                    break;
                case "2":
                    await FindCountryAsync();
                    break;
                case "3":
                    await CreateCountryAsync();
                    break;
                case "4":
                    await UpdateCountryAsync();
                    break;
                case "5":
                    await DeleteCountryAsync();
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

    private async Task ListCountriesAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Listado General de Países ---");
        
        var countries = await _services.GetAllAsync();
        bool hasData = false;

        foreach (var country in countries)
        {
            hasData = true;
            Console.WriteLine($"- ID: {country.Id} | Código ISO: {country.Code} | Nombre: {country.Name} | Activo: {(country.IsActive ? "Sí" : "No")}");
        }

        if (!hasData)
        {
            Console.WriteLine("No se encontraron países registrados en el sistema.");
        }

        Console.WriteLine("\nPresione cualquier tecla para regresar...");
        Console.ReadKey();
    }

    private async Task FindCountryAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Buscar País ---");
        Console.Write("Ingrese el código ISO del país (Ej: CO, ES, US): ");
        string? code = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(code))
        {
            var country = await _services.GetByCodeAsync(code.Trim().ToUpper());
            if (country != null)
            {
                Console.WriteLine("\n>> Datos Encontrados:");
                Console.WriteLine($"Nombre del País: {country.Name}");
                Console.WriteLine($"Código ISO: {country.Code}");
                Console.WriteLine($"Estado: {(country.IsActive ? "Activo" : "Inactivo")}");
                Console.WriteLine($"ID Único (GUID): {country.Id}");
            }
            else
            {
                Console.WriteLine($"\nNo se encontró un país bajo el código '{code}'.");
            }
        }
        else
        {
            Console.WriteLine("\nBúsqueda cancelada, código no válido.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateCountryAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Registro de Nuevo País ---");
        
        Console.Write("Nombre del País (ej: Colombia): ");
        string? name = Console.ReadLine();
        
        Console.Write("Código ISO Asociado (ej: CO, de 2 a 3 letras): ");
        string? code = Console.ReadLine();
        
        try
        {
            // La entidad Aggregate 'Country' se encarga internamente de validar las invariables lógicas
            var newCountry = Country.Create(name ?? "", code ?? "");
            await _services.CreateAsync(newCountry);
            Console.WriteLine($"\n¡El país {newCountry.Name} ({newCountry.Code}) se registró exitosamente!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError de violación a reglas de negocio o problemas al guardar:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task UpdateCountryAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Modificar País Existente ---");
        Console.Write("Para mayor precisión, ingrese el GUID del país a actualizar: ");
        
        if (!Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            Console.WriteLine("\nEl formato del ID es inválido.");
            Console.ReadKey();
            return;
        }

        var country = await _services.GetByIdAsync(id);
        if (country == null)
        {
            Console.WriteLine("\nNo se halló ningún registro con el ID suministrado.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\n* Presione Enter sin escribir nada en un campo si desea mantener la información actual:");

        Console.Write($"Nombre actual del país [{country.Name}]: ");
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name)) name = country.Name;

        Console.Write($"Código ISO del país [{country.Code}]: ");
        string? code = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(code)) code = country.Code;

        try
        {
            // Forzamos la actualización validando dentro de las reglas de dominio
            country.UpdateDetails(name, code);
            
            // Enviamos el objeto alterado a Application Service
            await _services.UpdateAsync(country);
            Console.WriteLine("\n¡Los datos del país fueron sobreescritos y actualizados con éxito!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nFalló el intento de actualización del país:\n-> {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }

    private async Task DeleteCountryAsync()
    {
        Console.Clear();
        Console.WriteLine("--- Eliminar Definitivamente un País ---");
        Console.Write("Precaución: Ingrese el GUID asociado al país que será eliminado del sistema: ");
        
        if (Guid.TryParse(Console.ReadLine(), out Guid id))
        {
            try
            {
                await _services.DeleteAsync(id);
                Console.WriteLine("\nEl país y su metadata se eliminaron de manera exitosa y persistente de la base de datos.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError crítico de Integridad. Algunos módulos pueden requerir que el país siga existiendo:\n-> {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("\nNo se proveyó un GUID estructuralmente correcto.");
        }

        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}
