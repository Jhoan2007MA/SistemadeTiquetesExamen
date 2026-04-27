using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.PaymentMethods.Application.Interfaces;
using SistemadeTiquetess.src.modules.PaymentMethods.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.PaymentMethods.UI;

public class PaymentMethodsMenu
{
    private readonly IPaymentMethodsServices _services;
    public PaymentMethodsMenu(IPaymentMethodsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("       Gestión de Métodos de Pago        ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los métodos");
            Console.WriteLine("2. Crear nuevo método");
            Console.WriteLine("3. Actualizar método");
            Console.WriteLine("4. Eliminar método");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListMethodsAsync(); break;
                case "2": await CreateMethodAsync(); break;
                case "3": await UpdateMethodAsync(); break;
                case "4": await DeleteMethodAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListMethodsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var m in list) Console.WriteLine($"- {m.Id}: {m.Name}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreateMethodAsync()
    {
        Console.Write("Nombre del método: ");
        string name = Console.ReadLine() ?? "";
        try {
            var method = PaymentMethod.Create(name);
            await _services.CreateAsync(method);
            Console.WriteLine("Método creado.");
        } catch(Exception e) { Console.WriteLine(e.Message); }
        Console.ReadKey();
    }

    private async Task UpdateMethodAsync()
    {
        Console.Write("ID del método a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var method = await _services.GetByIdAsync(id);
            if (method != null) {
                Console.Write($"Nuevo nombre [{method.Name}]: ");
                string newName = Console.ReadLine() ?? "";
                if (!string.IsNullOrWhiteSpace(newName)) {
                    method.UpdateName(newName);
                    await _services.UpdateAsync(method);
                    Console.WriteLine("Actualizado.");
                }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeleteMethodAsync()
    {
        Console.Write("ID del método a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
