using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Payments.Application.Interfaces;
using SistemadeTiquetess.src.modules.Payments.Domain.Aggregate;

namespace SistemadeTiquetess.src.modules.Payments.UI;

public class PaymentsMenu
{
    private readonly IPaymentsServices _services;
    public PaymentsMenu(IPaymentsServices services) => _services = services;

    public async Task ShowMenuAsync()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=========================================");
            Console.WriteLine("           Gestión de Pagos              ");
            Console.WriteLine("=========================================");
            Console.WriteLine("1. Ver todos los pagos");
            Console.WriteLine("2. Registrar nuevo pago");
            Console.WriteLine("3. Actualizar pago");
            Console.WriteLine("4. Eliminar registro de pago");
            Console.WriteLine("5. Volver");
            Console.WriteLine("=========================================");
            Console.Write("Seleccione: ");

            switch (Console.ReadLine())
            {
                case "1": await ListPaymentsAsync(); break;
                case "2": await CreatePaymentAsync(); break;
                case "3": await UpdatePaymentAsync(); break;
                case "4": await DeletePaymentAsync(); break;
                case "5": isRunning = false; break;
            }
        }
    }

    private async Task ListPaymentsAsync()
    {
        Console.Clear();
        var list = await _services.GetAllAsync();
        foreach (var p in list) 
            Console.WriteLine($"- ID: {p.Id} | Reserva: {p.ReservationId} | Monto: {p.Amount} | Fecha: {p.PaymentDate}");
        Console.WriteLine("\nPresione tecla para continuar...");
        Console.ReadKey();
    }

    private async Task CreatePaymentAsync()
    {
        Console.Write("ID de la Reserva (GUID): ");
        if (Guid.TryParse(Console.ReadLine(), out Guid resId)) {
            Console.Write("ID del Método de Pago (GUID): ");
            if (Guid.TryParse(Console.ReadLine(), out Guid methodId)) {
                Console.Write("Monto a pagar: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount)) {
                    try {
                        var payment = Payment.Create(resId, methodId, amount);
                        await _services.CreateAsync(payment);
                        Console.WriteLine("Pago registrado.");
                    } catch(Exception e) { Console.WriteLine(e.Message); }
                }
            }
        }
        Console.ReadKey();
    }

    private async Task UpdatePaymentAsync()
    {
        Console.Write("ID del pago a editar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            var payment = await _services.GetByIdAsync(id);
            if (payment != null) {
                Console.Write($"Nuevo ID Método de Pago [{payment.PaymentMethodId}]: ");
                string methodIn = Console.ReadLine() ?? "";
                Guid methodId = string.IsNullOrWhiteSpace(methodIn) ? payment.PaymentMethodId : (Guid.TryParse(methodIn, out Guid mId) ? mId : payment.PaymentMethodId);

                Console.Write($"Nuevo Monto [{payment.Amount}]: ");
                string amountIn = Console.ReadLine() ?? "";
                decimal amount = string.IsNullOrWhiteSpace(amountIn) ? payment.Amount : (decimal.TryParse(amountIn, out decimal amt) ? amt : payment.Amount);

                try {
                    payment.UpdateDetails(methodId, amount);
                    await _services.UpdateAsync(payment);
                    Console.WriteLine("Actualizado.");
                } catch(Exception e) { Console.WriteLine(e.Message); }
            } else Console.WriteLine("No encontrado.");
        }
        Console.ReadKey();
    }

    private async Task DeletePaymentAsync()
    {
        Console.Write("ID del pago a borrar: ");
        if (Guid.TryParse(Console.ReadLine(), out Guid id)) {
            await _services.DeleteAsync(id);
            Console.WriteLine("Borrado.");
        }
        Console.ReadKey();
    }
}
