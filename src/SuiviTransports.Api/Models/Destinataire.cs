namespace SuiviTransports.Api.Models;

public class Destinataire
{
    public int Id { get; set; }

    public string Nom { get; set; } = string.Empty;

    // Pharmacie, Hopital, Laboratoire
    public string Type { get; set; } = string.Empty;

    public string Adresse { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Telephone { get; set; } = string.Empty;

    public virtual List<Transport> Transports { get; set; } = new();
}
