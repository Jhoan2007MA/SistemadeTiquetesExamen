using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.SeatAssignments.Application.Interfaces;
using SistemadeTiquetess.src.modules.SeatAssignments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.SeatAssignments.UI;

public class SeatAssignmentsMenu
{
    private readonly ISeatAssignmentsServices _services;
    public SeatAssignmentsMenu(ISeatAssignmentsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("        Asignación de Asientos           ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todas las asignaciones");
            Console.WriteLine("2. Asignar asiento a pasajero");
            Console.WriteLine("3. Reasignar asiento");
            Console.WriteLine("4. Eliminar asignación");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListAssignmentsAsync(); break;
                case "2": await CreateAssignmentAsync(); break;
                case "3": await UpdateAssignmentAsync(); break;
                case "4": await DeleteAssignmentAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListAssignmentsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var a in list) 
            Console.WriteLine($"- ID: {a.Id} | Pasajero de Reserva: {a.ReservationPassengerId} | Asiento: {a.SeatId}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateAssignmentAsync()
    {
        Console.Write("ID del Pasajero de Reserva (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid passId)) {
            Console.Write("ID del Asiento (GUID): ");
            if (Guid.TryParse(Console.ReadLine(), out Guid seatId)) {
                var assign = SeatAssignment.Create(passId, seatId);
                await _services.CreateAsync(assign);
                Console.WriteLine("Asiento asignado.");
            }
        }
        Console.ReadKey();
    }

    private async Task UpdateAssignmentAsync()
    {
        Console.Write("ID de la asignación a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var assign = await _services.GetByIdAsync(id);
            if (assign != null) {
                Console.Write($"Nuevo ID de Asiento [{assign.SeatId}]: ");
                if (Guid.TryParse(Console.ReadLine(), out Guid newSeatId)) {
                    assign.UpdateSeat(newSeatId);
                    await _services.UpdateAsync(assign);
                    Console.WriteLine("Actualizado.");
                }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteAssignmentAsync()
    {
        Console.Write("ID de la asignación a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
