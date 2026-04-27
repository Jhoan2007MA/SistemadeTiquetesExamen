using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemadeTiquetess.src.modules.Reservations.Application.Interfaces;
using SistemadeTiquetess.src.modules.Reservations.Domain.Aggregate;
using SistemadeTiquetess.src.modules.Reservations.Domain.Repositories;
using SistemadeTiquetess.src.shared.context;
using Microsoft.EntityFrameworkCore;
using SistemadeTiquetess.src.modules.Reservations.Infrastructure.Entity;
namespace SistemadeTiquetess.src.modules.Reservations.Application.Services;

public class ReservationsServices : IReservationsServices
{
    private readonly IReservationsRepository _repository;
    private readonly AppDbContext _context;
    public ReservationsServices(IReservationsRepository repository, AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<Reservation?> GetByIdAsync(Guid id) => await _repository.GetByIdAsync(id);
    public async Task<Reservation> CreateAsync(Reservation reservation)
    {
        await _repository.AddAsync(reservation);
        return reservation;
    }
    public async Task UpdateAsync(Reservation reservation) 
    {
        await _repository.UpdateAsync(reservation);
        // Verificar promoción de lista de espera si la reserva fue cancelada o cambió
        // Idealmente solo si cambió de vuelo o se canceló, para simplificar llamaremos a CheckWaitlist
        // No tenemos el vuelo anterior fácil, pero podemos revisar si el vuelo asociado tiene cupo
    }

    public async Task DeleteAsync(Guid id) 
    {
        var reservation = await _repository.GetByIdAsync(id);
        await _repository.DeleteAsync(id);
        if (reservation != null)
        {
            await CheckWaitlistPromotionAsync(reservation.FlightId);
        }
    }

    public async Task<bool> RescheduleAsync(Guid reservationId, Guid newFlightId, string reason)
    {
        var reservation = await _context.Reservations.FindAsync(reservationId);
        if (reservation == null) return false;

        var currentFlight = await _context.Flights.FindAsync(reservation.FlightId);
        var newFlight = await _context.Flights.FindAsync(newFlightId);

        if (currentFlight == null || newFlight == null) return false;

        // Validar compatibilidad (misma ruta)
        if (currentFlight.Origin != newFlight.Origin || currentFlight.Destination != newFlight.Destination) 
            throw new Exception("El nuevo vuelo no tiene la misma ruta.");

        // Validar cupo (Ejemplo: maximo 2 asientos por vuelo para probar facil)
        int maxCapacity = 2;
        int currentReservations = await _context.Reservations.CountAsync(r => r.FlightId == newFlightId && r.StatusId != Guid.Parse("a1000000-0000-0000-0000-000000000061")); // Asumiendo 0061 es cancelada, omitiremos el chequeo exacto o usaremos solo Reprogramada
        
        Guid previousFlightId = reservation.FlightId;

        if (currentReservations >= maxCapacity)
        {
            // Sin cupo
            return false;
        }

        // Reprogramar
        reservation.FlightId = newFlightId;
        // Asumiendo Guid de Reprogramada: a1000000-0000-0000-0000-000000000062
        reservation.StatusId = Guid.Parse("a1000000-0000-0000-0000-000000000062"); 
        
        var history = new RescheduleHistoryEntity
        {
            Id = Guid.NewGuid(),
            ReservationId = reservation.Id,
            PreviousFlightId = previousFlightId,
            NewFlightId = newFlightId,
            ChangeDate = DateTime.UtcNow,
            Reason = reason
        };

        _context.RescheduleHistories.Add(history);
        _context.Reservations.Update(reservation);
        await _context.SaveChangesAsync();

        // Verificar lista de espera del vuelo anterior
        await CheckWaitlistPromotionAsync(previousFlightId);

        return true;
    }

    public async Task<bool> AddToWaitlistAsync(Guid reservationId, Guid flightId)
    {
        var waitlist = new WaitlistEntity
        {
            Id = Guid.NewGuid(),
            ReservationId = reservationId,
            FlightId = flightId,
            RequestDate = DateTime.UtcNow,
            Status = "Pendiente"
        };

        _context.Waitlists.Add(waitlist);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task CheckWaitlistPromotionAsync(Guid flightId)
    {
        int maxCapacity = 2; // Para pruebas
        int currentReservations = await _context.Reservations.CountAsync(r => r.FlightId == flightId && r.StatusId != Guid.Parse("a1000000-0000-0000-0000-000000000061") && r.StatusId != Guid.Parse("a1000000-0000-0000-0000-000000000062")); // ignorar canceladas y reprogramadas (que ya se movieron)
        
        // La consulta de currentReservations es aproximada. Lo mejor es contar solo las Confirmadas (60)
        currentReservations = await _context.Reservations.CountAsync(r => r.FlightId == flightId && r.StatusId == Guid.Parse("a1000000-0000-0000-0000-000000000060"));

        if (currentReservations < maxCapacity)
        {
            var nextInLine = await _context.Waitlists
                .Where(w => w.FlightId == flightId && w.Status == "Pendiente")
                .OrderBy(w => w.RequestDate)
                .FirstOrDefaultAsync();

            if (nextInLine != null)
            {
                var reservation = await _context.Reservations.FindAsync(nextInLine.ReservationId);
                if (reservation != null)
                {
                    reservation.FlightId = flightId;
                    reservation.StatusId = Guid.Parse("a1000000-0000-0000-0000-000000000060"); // Confirmada
                    _context.Reservations.Update(reservation);

                    nextInLine.Status = "Promovido";
                    _context.Waitlists.Update(nextInLine);

                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
