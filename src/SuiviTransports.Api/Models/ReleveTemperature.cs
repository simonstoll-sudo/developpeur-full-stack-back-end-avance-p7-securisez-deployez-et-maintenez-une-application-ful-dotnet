namespace SuiviTransports.Api.Models;

public class ReleveTemperature
{
    public int Id { get; set; }

    public int TransportId { get; set; }

    public DateTime HorodatageUtc { get; set; }

    public double ValeurCelsius { get; set; }

    public string CapteurId { get; set; } = string.Empty;

    public virtual Transport? Transport { get; set; }
}
