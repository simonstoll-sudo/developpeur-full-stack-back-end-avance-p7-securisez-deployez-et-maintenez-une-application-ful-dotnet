namespace SuiviTransports.Api.Models;

public class Transport
{
    public int Id { get; set; }

    public string Reference { get; set; } = string.Empty;

    public string TypeProduit { get; set; } = string.Empty;

    // EnPreparation, EnCours, Livre, Incident
    public string Statut { get; set; } = "EnPreparation";

    public string SiteDepart { get; set; } = string.Empty;

    public string SiteArrivee { get; set; } = string.Empty;

    public DateTime DateDepart { get; set; }

    public DateTime DateArriveePrevue { get; set; }

    public DateTime? DateArriveeReelle { get; set; }

    public string? NomPatient { get; set; }

    public DateOnly? DateNaissancePatient { get; set; }

    public int DestinataireId { get; set; }

    public virtual Destinataire? Destinataire { get; set; }

    public virtual List<ReleveTemperature> Releves { get; set; } = new();
}
