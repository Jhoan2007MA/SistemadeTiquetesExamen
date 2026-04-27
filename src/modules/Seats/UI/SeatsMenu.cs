using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Seats.Application.Interfaces;
using SistemadeTiquetess.src.modules.Seats.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Seats.UI;

public class SeatsMenu
{
    private readonly ISeatsServices _services;
    public SeatsMenu(ISeatsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("          Gestión de Asientos            ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los asientos");
            Console.WriteLine("2. Crear nuevo asiento");
            Console.WriteLine("3. Actualizar asiento");
            Console.WriteLine("4. Eliminar asiento");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListSeatsAsync(); break;
                case "2": await CreateSeatAsync(); break;
                case "3": await UpdateSeatAsync(); break;
                case "4": await DeleteSeatAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListSeatsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var s in list) 
            Console.WriteLine($"- {s.Id}: {s.SeatNumber} (Fila: {s.Row} | Clase: {s.Class})");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateSeatAsync()
    {
        Console.Write("Número de asiento: ");
        string num = Console.ReadLine() ?? "";
        Console.Write("Fila: ");
        string row = Console.ReadLine() ?? "";
        Console.Write("Clase: ");
        string sClass = Console.ReadLine() ?? "";

        try {
            var seat = Seat.Create(num, row, sClass);
            await _services.CreateAsync(seat);
            Console.WriteLine("Asiento creado.");
        } catch(Exception e) { Console.WriteLine(e.Message); }
        Console.ReadKey();
    }

    private async Task UpdateSeatAsync()
    {
        Console.Write("ID del asiento a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var seat = await _services.GetByIdAsync(id);
            if (seat != null) {
                Console.Write($"Nuevo Número [{seat.SeatNumber}]: ");
                string num = Console.ReadLine() ?? seat.SeatNumber;
                Console.Write($"Nueva Fila [{seat.Row}]: ");
                string row = Console.ReadLine() ?? seat.Row;
                Console.Write($"Nueva Clase [{seat.Class}]: ");
                string sClass = Console.ReadLine() ?? seat.Class;

                seat.UpdateDetails(num, row, sClass);
                await _services.UpdateAsync(seat);
                Console.WriteLine("Actualizado.");
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteSeatAsync()
    {
        Console.Write("ID del asiento a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
