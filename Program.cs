using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.shared.context;
using SistemadeTiquetess.src.shared.helpers;
using SistemadeTiquetess.src.shared.ui.Menus;

try
{
    using var context = DbContextFactory.Create();
    Console.WriteLine("Aplicando migraciones pendientes en la base de datos...");
    await context.Database.MigrateAsync();

    if (context.Database.CanConnect())
    {
        Console.WriteLine("Base de datos lista. Conexión correcta.");
        await new ConsoleMenuOrchestrator().StartAsync();
    }
    else
    {
        Console.WriteLine("No se pudo conectar con la base de datos.");
    }
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Error con la base de datos: {ex.Message}");
    if (ex.InnerException is not null)
    {
        Console.Error.WriteLine($"Detalle: {ex.InnerException.Message}");
    }
    Console.Error.WriteLine();
    Console.Error.WriteLine("Pulsa una tecla para salir...");
    try { Console.ReadKey(true); } catch (InvalidOperationException) { }
}