using System;
using System.Threading.Tasks;
using SistemadeTiquetess.src.shared.helpers;
using SistemadeTiquetess.src.modules.Airlines.UI;
using SistemadeTiquetess.src.modules.Airlines.Application.Services;
using SistemadeTiquetess.src.modules.Airlines.infrastructure.Repositories;
using SistemadeTiquetess.src.modules.Countries.UI;
using SistemadeTiquetess.src.modules.Countries.Application.Services;
using SistemadeTiquetess.src.modules.Countries.Infrastructure.Repositories;
using SistemadeTiquetess.src.modules.Flights.UI;
using SistemadeTiquetess.src.modules.Flights.Application.Services;
using SistemadeTiquetess.src.modules.Flights.Infrastructure.Repositories;
using SistemadeTiquetess.src.modules.Aircrafts.UI;
using SistemadeTiquetess.src.modules.Aircrafts.Application.Services;
using SistemadeTiquetess.src.modules.Aircrafts.infrastructure.Repositories;
using SistemadeTiquetess.src.modules.Customers.UI;
using SistemadeTiquetess.src.modules.Customers.Application.Services;
using SistemadeTiquetess.src.modules.Customers.Infrastructure.Repositories;
using SistemadeTiquetess.src.modules.Reservations.UI;
using SistemadeTiquetess.src.modules.Reservations.Application.Services;
using SistemadeTiquetess.src.modules.Reservations.Infrastructure.Repositories;

namespace SistemadeTiquetess.src.shared.ui.Menus;

public class ConsoleMenuOrchestrator
{
    public async Task StartAsync()
    {
        bool exit = false;

        using var context = DbContextFactory.Create();

        while (!exit)
        {
            try {
                Console.Clear();
            } catch (Exception) { /* Ignorar si falla en entorno no interactivo */ }

            Console.WriteLine("========================================");
            Console.WriteLine("       SISTEMA DE TIQUETES             ");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Gestión de Aerolíneas");
            Console.WriteLine("2. Gestión de Aeronaves");
            Console.WriteLine("3. Gestión de Vuelos");
            Console.WriteLine("4. Gestión de Clientes");
            Console.WriteLine("5. Gestión de Reservas y Tiquetes");
            Console.WriteLine("6. Configuración Geográfica (Países)");
            Console.WriteLine("0. Salir");
            Console.WriteLine("========================================");
            Console.Write("Seleccione una opción: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    var airlineRepo = new AirlinesRepository(context);
                    var airlineService = new AirlinesServices(airlineRepo);
                    await new AirlineMenu(airlineService).ShowMenuAsync();
                    break;
                case "2":
                    var aircraftRepo = new AircraftsRepository(context);
                    var aircraftService = new AircraftsServices(aircraftRepo);
                    await new AircraftMenu(aircraftService).ShowMenuAsync();
                    break;
                case "3":
                    var flightRepo = new FlightsRepository(context);
                    var flightService = new FlightsServices(flightRepo);
                    await new FlightsMenu(flightService).ShowMenuAsync();
                    break;
                case "4":
                    var customerRepo = new CustomersRepository(context);
                    var customerService = new CustomersServices(customerRepo);
                    await new CustomersMenu(customerService).ShowMenuAsync();
                    break;
                case "5":
                    var resRepo = new ReservationsRepository(context);
                    var resService = new ReservationsServices(resRepo);
                    await new ReservationsMenu(resService).ShowMenuAsync();
                    break;
                case "6":
                    var countryRepo = new CountriesRepository(context);
                    var countryService = new CountriesServices(countryRepo);
                    await new CountriesMenu(countryService).ShowMenuAsync();
                    break;
                case "0":
                    exit = true;
                    Console.WriteLine("\nSaliendo del orquestador de menús...");
                    break;
                default:
                    Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                    Pause();
                    break;
            }
        }
    }

    private void Pause()
    {
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        try {
            Console.ReadKey();
        } catch (Exception) { }
    }
}
