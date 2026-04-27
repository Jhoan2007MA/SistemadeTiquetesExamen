using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.TicketStatus.Application.Interfaces;
using SistemadeTiquetess.src.modules.TicketStatus.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.TicketStatus.UI;

public class TicketStatusMenu
{
    private readonly ITicketStatusServices _services;
    public TicketStatusMenu(ITicketStatusServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("      Gestión de Estados de Tiquete      ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los estados");
            Console.WriteLine("2. Crear nuevo estado");
            Console.WriteLine("3. Actualizar estado");
            Console.WriteLine("4. Eliminar estado");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListStatusAsync(); break;
                case "2": await CreateStatusAsync(); break;
                case "3": await UpdateStatusAsync(); break;
                case "4": await DeleteStatusAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListStatusAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var s in list) Console.WriteLine($"- {s.Id}: {s.Name}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateStatusAsync()
    {
        Console.Write("Nombre del estado de tiquete: ");
        string name = Console.ReadLine() ?? "";
        try {
            var status = TicketStatusAggregate.Create(name);
            await _services.CreateAsync(status);
            Console.WriteLine("Estado creado.");
        } catch(Exception e) { Console.WriteLine(e.Message); }
        Console.ReadKey();
    }

    private async Task UpdateStatusAsync()
    {
        Console.Write("ID del estado a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var status = await _services.GetByIdAsync(id);
            if (status != null) {
                Console.Write($"Nuevo nombre [{status.Name}]: ");
                string newName = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newName)) {
                    status.UpdateName(newName);
                    await _services.UpdateAsync(status);
                    Console.WriteLine("Actualizado.");
                }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteStatusAsync()
    {
        Console.Write("ID del estado a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
