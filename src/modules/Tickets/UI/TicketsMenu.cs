using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Tickets.Application.Interfaces;
using SistemadeTiquetess.src.modules.Tickets.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Tickets.UI;

public class TicketsMenu
{
    private readonly ITicketsServices _services;
    public TicketsMenu(ITicketsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("           Gestión de Tiquetes           ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los tiquetes");
            Console.WriteLine("2. Emitir nuevo tiquete");
            Console.WriteLine("3. Cambiar estado de tiquete");
            Console.WriteLine("4. Eliminar tiquete");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListTicketsAsync(); break;
                case "2": await CreateTicketAsync(); break;
                case "3": await UpdateTicketAsync(); break;
                case "4": await DeleteTicketAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListTicketsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var t in list) 
            Console.WriteLine($"- ID: {t.Id} | Número: {t.TicketNumber} | Estado: {t.StatusId} | Fecha: {t.IssueDate}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateTicketAsync()
    {
        Console.Write("ID del Pasajero de Reserva (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid passId)) {
            Console.Write("ID del Estado Inicial (GUID): ");
            if (Guid.TryParse(Console.ReadLine(), out Guid statusId)) {
                Console.Write("Número de Tiquete (Cod.): ");
                string num = Console.ReadLine() ?? "";
                try {
                    var ticket = Ticket.Create(passId, statusId, num);
                    await _services.CreateAsync(ticket);
                    Console.WriteLine("Tiquete emitido.");
                } catch(Exception e) { Console.WriteLine(e.Message); }
            }
        }
        Console.ReadKey();
    }

    private async Task UpdateTicketAsync()
    {
        Console.Write("ID del tiquete a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var ticket = await _services.GetByIdAsync(id);
            if (ticket != null) {
                Console.Write($"Nuevo ID de Estado [{ticket.StatusId}]: ");
                if (Guid.TryParse(Console.ReadLine(), out Guid newStatusId)) {
                    ticket.UpdateStatus(newStatusId);
                    await _services.UpdateAsync(ticket);
                    Console.WriteLine("Actualizado.");
                }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteTicketAsync()
    {
        Console.Write("ID del tiquete a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
