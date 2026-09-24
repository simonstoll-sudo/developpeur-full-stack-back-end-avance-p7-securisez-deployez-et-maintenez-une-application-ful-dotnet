namespace SuiviTransports.Api.Models;

public class Utilisateur
{
    public int Id { get; set; }

    public string NomUtilisateur { get; set; } = string.Empty;

    public string MotDePasse { get; set; } = string.Empty;

    // Admin, Responsable, Livreur
    public string Role { get; set; } = "Livreur";
}
