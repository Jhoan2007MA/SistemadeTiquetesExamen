using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.ReservationPassengers.Application.Interfaces;
using SistemadeTiquetess.src.modules.ReservationPassengers.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.ReservationPassengers.UI;

public class ReservationPassengersMenu
{
    private readonly IReservationPassengersServices _services;
    public ReservationPassengersMenu(IReservationPassengersServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          Gestión de Pasajeros           ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los pasajeros de reservas");
            Console.WriteLine("2. Añadir pasajero a reserva");
            Console.WriteLine("3. Cambiar asiento de pasajero");
            Console.WriteLine("4. Eliminar pasajero");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListPassengersAsync(); break;
                case "2": await CreatePassengerAsync(); break;
                case "3": await UpdatePassengerAsync(); break;
                case "4": await DeletePassengerAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListPassengersAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var p in list) 
            Console.WriteLine($"- ID: {p.Id} | Reserva: {p.ReservationId} | Cliente: {p.CustomerId} | Asiento: {p.SeatNumber}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreatePassengerAsync()
    {
        Console.Write("ID de la Reserva (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid resId)) {
            Console.Write("ID del Pasajero/Cliente (GUID): ");
            if (Guid.TryParse(Console.ReadLine(), out Guid custId)) {
                Console.Write("Número de Asiento: ");
                string seat = Console.ReadLine() ?? "";
                try {
                    var p = ReservationPassenger.Create(resId, custId, seat);
                    await _services.CreateAsync(p);
                    Console.WriteLine("Pasajero añadido.");
                } catch(Exception e) { Console.WriteLine(e.Message); }
            }
        }
        Console.ReadKey();
    }

    private async Task UpdatePassengerAsync()
    {
        Console.Write("ID del registro a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var p = await _services.GetByIdAsync(id);
            if (p != null) {
                Console.Write($"Nuevo Asiento [{p.SeatNumber}]: ");
                string seat = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(seat)) {
                    p.UpdateSeat(seat);
                    await _services.UpdateAsync(p);
                    Console.WriteLine("Actualizado.");
                }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeletePassengerAsync()
    {
        Console.Write("ID del registro a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
