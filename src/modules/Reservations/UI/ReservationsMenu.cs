using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Reservations.Application.Interfaces;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Reservations.UI;

public class ReservationsMenu
{
    private readonly IReservationsServices _services;
    public ReservationsMenu(IReservationsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          Gestión de Reservas            ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todas las reservas");
            Console.WriteLine("2. Crear nueva reserva");
            Console.WriteLine("3. Actualizar estado de reserva");
            Console.WriteLine("4. Eliminar reserva");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListReservationsAsync(); break;
                case "2": await CreateReservationAsync(); break;
                case "3": await UpdateReservationAsync(); break;
                case "4": await DeleteReservationAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListReservationsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var r in list) 
            Console.WriteLine($"- ID: {r.Id} | Cliente: {r.CustomerId} | Vuelo: {r.FlightId} | Fecha: {r.ReservationDate} | Estado: {r.Status}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateReservationAsync()
    {
        Console.Write("ID del Cliente (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid custId)) {
            Console.Write("ID del Vuelo (GUID): ");
            if (Guid.TryParse(Console.ReadLine(), out Guid flightId)) {
                try {
                    var res = Reservation.Create(custId, flightId);
                    await _services.CreateAsync(res);
                    Console.WriteLine("Reserva creada.");
                } catch(Exception e) { Console.WriteLine(e.Message); }
            }
        }
        Console.ReadKey();
    }

    private async Task UpdateReservationAsync()
    {
        Console.Write("ID de la reserva a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var res = await _services.GetByIdAsync(id);
            if (res != null) {
                Console.Write($"Nuevo Estado [{res.Status}]: ");
                string newStatus = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newStatus)) {
                    res.UpdateStatus(newStatus);
                    await _services.UpdateAsync(res);
                    Console.WriteLine("Actualizado.");
                }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteReservationAsync()
    {
        Console.Write("ID de la reserva a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
