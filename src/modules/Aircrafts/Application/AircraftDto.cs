namespace SistemadeTiquetess.src.modules.Aircrafts.Application;

public class AircraftDto
{
    public Guid Id { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
}
