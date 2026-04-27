using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.FlightSegments.Application.Interfaces;
using SistemadeTiquetess.src.modules.FlightSegments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.FlightSegments.UI;

public class FlightSegmentsMenu
{
    private readonly IFlightSegmentsServices _services;
    public FlightSegmentsMenu(IFlightSegmentsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          Gestión de Segmentos           ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los segmentos");
            Console.WriteLine("2. Crear nuevo segmento");
            Console.WriteLine("3. Actualizar segmento");
            Console.WriteLine("4. Eliminar segmento");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListSegmentsAsync(); break;
                case "2": await CreateSegmentAsync(); break;
                case "3": await UpdateSegmentAsync(); break;
                case "4": await DeleteSegmentAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListSegmentsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var s in list) 
            Console.WriteLine($"- ID: {s.Id} | VueloID: {s.FlightId} | OrigenID: {s.OriginAirportId} | DestinoID: {s.DestinationAirportId}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateSegmentAsync()
    {
        Console.Write("ID del Vuelo (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid flightId)) {
            Console.Write("ID Aeropuerto Origen (GUID): ");
            if (Guid.TryParse(Console.ReadLine(), out Guid originId)) {
                Console.Write("ID Aeropuerto Destino (GUID): ");
                if (Guid.TryParse(Console.ReadLine(), out Guid destId)) {
                    var segment = FlightSegment.Create(flightId, originId, destId);
                    await _services.CreateAsync(segment);
                    Console.WriteLine("Segmento creado.");
                }
            }
        }
        Console.ReadKey();
    }

    private async Task UpdateSegmentAsync()
    {
        Console.Write("ID del segmento a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var segment = await _services.GetByIdAsync(id);
            if (segment != null) {
                Console.Write($"Nuevo ID Origen [{segment.OriginAirportId}]: ");
                string originIn = Console.ReadLine() ?? "";
                Guid originId = string.IsNullOrWhiteSpace(originIn) ? segment.OriginAirportId : (Guid.TryParse(originIn, out Guid oId) ? oId : segment.OriginAirportId);

                Console.Write($"Nuevo ID Destino [{segment.DestinationAirportId}]: ");
                string destIn = Console.ReadLine() ?? "";
                Guid destId = string.IsNullOrWhiteSpace(destIn) ? segment.DestinationAirportId : (Guid.TryParse(destIn, out Guid dId) ? dId : segment.DestinationAirportId);

                segment.UpdateRoute(originId, destId);
                await _services.UpdateAsync(segment);
                Console.WriteLine("Actualizado.");
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteSegmentAsync()
    {
        Console.Write("ID del segmento a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
