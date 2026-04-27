using System;

namespace SistemadeTiquetess.src.shared.ui.Menus;

public class LoginMenu
{
    public bool Show()
    {
        bool isAuthenticated = false;

        while (!isAuthenticated)
        {
            Console.Clear();
            Console.WriteLine("========================================");
            Console.WriteLine("        INICIO DE SESIÓN AL SISTEMA     ");
            Console.WriteLine("========================================");
            
            Console.Write("Usuario/Email: ");
            string? username = Console.ReadLine();

            Console.Write("Contraseña: ");
            string password = ReadPassword();

            // TODO: Integrar lógica real de autenticación a través de base de datos o servicio.
            // Credenciales estáticas de prueba:
            if (username == "admin" && password == "admin123")
            {
                Console.WriteLine("\n\n¡Inicio de sesión exitoso!");
                isAuthenticated = true;
                Pause();
            }
            else
            {
                Console.WriteLine("\n\nCredenciales incorrectas. Intente nuevamente.");
                Console.WriteLine("Presione Esc para salir o cualquier otra tecla para reintentar...");
                var keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    return false;
                }
            }
        }

        return isAuthenticated;
    }

    private string ReadPassword()
    {
        string password = string.Empty;
        ConsoleKey key;

        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1]; // Elimina el último caracter
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        return password;
    }

    private void Pause()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey(intercept: true);
    }
}
