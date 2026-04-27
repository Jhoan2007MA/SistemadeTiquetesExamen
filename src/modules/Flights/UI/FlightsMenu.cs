using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Flights.Application.Interfaces;
using SistemadeTiquetess.src.modules.Flights.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Flights.UI;

public class FlightsMenu
{
    private readonly IFlightsServices _services;
    public FlightsMenu(IFlightsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("           Gestión de Vuelos             ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los vuelos");
            Console.WriteLine("2. Crear nuevo vuelo");
            Console.WriteLine("3. Actualizar vuelo");
            Console.WriteLine("4. Eliminar vuelo");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListFlightsAsync(); break;
                case "2": await CreateFlightAsync(); break;
                case "3": await UpdateFlightAsync(); break;
                case "4": await DeleteFlightAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListFlightsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var f in list) 
            Console.WriteLine($"- ID: {f.Id} | Número: {f.FlightNumber} | StatusID: {f.StatusId}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateFlightAsync()
    {
        Console.Write("Número de vuelo (ej: AV123): ");
        string number = Console.ReadLine() ?? "";
        Console.Write("ID del Estado (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid statusId)) {
            try {
                var flight = Flight.Create(number, statusId);
                await _services.CreateAsync(flight);
                Console.WriteLine("Vuelo creado.");
            } catch(Exception e) { Console.WriteLine(e.Message); }
        } else Console.WriteLine("ID de estado inválido.");
        Console.ReadKey();
    }

    private async Task UpdateFlightAsync()
    {
        Console.Write("ID del vuelo a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var flight = await _services.GetByIdAsync(id);
            if (flight != null) {
                Console.Write($"Nuevo número [{flight.FlightNumber}]: ");
                string newNumber = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(newNumber)) newNumber = flight.FlightNumber;
                
                Console.Write($"Nuevo ID de Estado [{flight.StatusId}]: ");
                string statusIn = Console.ReadLine() ?? "";
                Guid statusId = string.IsNullOrWhiteSpace(statusIn) ? flight.StatusId : (Guid.TryParse(statusIn, out Guid sId) ? sId : flight.StatusId);

                try {
                    flight.UpdateDetails(newNumber, statusId);
                    await _services.UpdateAsync(flight);
                    Console.WriteLine("Actualizado.");
                } catch(Exception e) { Console.WriteLine(e.Message); }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteFlightAsync()
    {
        Console.Write("ID del vuelo a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
