using System;

namespace SistemadeTiquetess.src.modules.Seats.Infrastructure.Entity;

public class SeatEntity
{
    public Guid Id { get; set; }
    public string SeatNumber { get; set; } = string.Empty;
    public string Row { get; set; } = string.Empty;
    public string Class { get; set; } = string.Empty;
}
