using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAvailability.Application.Interfaces;
using SistemadeTiquetess.src.modules.SeatAvailability.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAvailability.UI;

public class SeatAvailabilityMenu
{
    private readonly ISeatAvailabilityServices _services;
    public SeatAvailabilityMenu(ISeatAvailabilityServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("        Disponibilidad de Asientos       ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver toda la disponibilidad");
            Console.WriteLine("2. Configurar disponibilidad (Asiento/Vuelo)");
            Console.WriteLine("3. Cambiar estado (Disponible/Ocupado)");
            Console.WriteLine("4. Eliminar registro");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListAvailabilityAsync(); break;
                case "2": await CreateAvailabilityAsync(); break;
                case "3": await UpdateAvailabilityAsync(); break;
                case "4": await DeleteAvailabilityAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListAvailabilityAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var a in list) 
            Console.WriteLine($"- ID: {a.Id} | Asiento: {a.SeatId} | Vuelo: {a.FlightId} | Disponible: {(a.IsAvailable ? "SI" : "NO")}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateAvailabilityAsync()
    {
        Console.Write("ID del Asiento (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid seatId)) {
            Console.Write("ID del Vuelo (GUID): ");
            if (Guid.TryParse(Console.ReadLine(), out Guid flightId)) {
                var avail = SeatAvailabilityAggregate.Create(seatId, flightId);
                await _services.CreateAsync(avail);
                Console.WriteLine("Configuración guardada.");
            }
        }
        Console.ReadKey();
    }

    private async Task UpdateAvailabilityAsync()
    {
        Console.Write("ID del registro a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var avail = await _services.GetByIdAsync(id);
            if (avail != null) {
                Console.Write($"¿Está disponible? (s/n): ");
                bool isAvail = Console.ReadLine()?.ToLower() == "s";
                avail.ToggleAvailability(isAvail);
                await _services.UpdateAsync(avail);
                Console.WriteLine("Actualizado.");
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteAvailabilityAsync()
    {
        Console.Write("ID del registro a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
