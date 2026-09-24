using SuiviTransports.Api.Models;

namespace SuiviTransports.Api.Data;

public static class DbSeeder
{
    public static void Seed(SuiviTransportsContext context)
    {
        context.Database.EnsureCreated();

        if (context.Transports.Any())
        {
            return;
        }

        var pharmacie = new Destinataire
        {
            Nom = "Pharmacie du Vieux Port",
            Type = "Pharmacie",
            Adresse = "12 quai des Belges, 13001 Marseille",
            Email = "contact@pharmacie-vieuxport.fr",
            Telephone = "04 91 54 20 11"
        };

        var hopital = new Destinataire
        {
            Nom = "Centre Hospitalier de Salon-de-Provence",
            Type = "Hopital",
            Adresse = "207 avenue Julien Fabre, 13300 Salon-de-Provence",
            Email = "pharmacie.centrale@ch-salon.fr",
            Telephone = "04 90 44 91 00"
        };

        var laboratoire = new Destinataire
        {
            Nom = "Laboratoire Biomed Provence",
            Type = "Laboratoire",
            Adresse = "4 rue des Frenes, 13100 Aix-en-Provence",
            Email = "reception@biomed-provence.fr",
            Telephone = "04 42 27 63 88"
        };

        context.Destinataires.AddRange(pharmacie, hopital, laboratoire);
        context.SaveChanges();

        var t1 = new Transport
        {
            Reference = "TR-2026-0114",
            TypeProduit = "Vaccins grippe saisonniere",
            Statut = "Livre",
            SiteDepart = "Entrepot Santelog Vitrolles",
            SiteArrivee = "Marseille",
            DateDepart = new DateTime(2026, 1, 12, 6, 30, 0, DateTimeKind.Utc),
            DateArriveePrevue = new DateTime(2026, 1, 12, 9, 0, 0, DateTimeKind.Utc),
            DateArriveeReelle = new DateTime(2026, 1, 12, 8, 52, 0, DateTimeKind.Utc),
            DestinataireId = pharmacie.Id
        };

        var t2 = new Transport
        {
            Reference = "TR-2026-0117",
            TypeProduit = "Insulines",
            Statut = "Livre",
            SiteDepart = "Entrepot Santelog Vitrolles",
            SiteArrivee = "Salon-de-Provence",
            DateDepart = new DateTime(2026, 1, 14, 5, 45, 0, DateTimeKind.Utc),
            DateArriveePrevue = new DateTime(2026, 1, 14, 8, 30, 0, DateTimeKind.Utc),
            DateArriveeReelle = new DateTime(2026, 1, 14, 10, 10, 0, DateTimeKind.Utc),
            DestinataireId = hopital.Id
        };

        var t3 = new Transport
        {
            Reference = "TR-2026-0121",
            TypeProduit = "Echantillons biologiques",
            Statut = "Incident",
            SiteDepart = "Clinique des Oliviers, Marignane",
            SiteArrivee = "Aix-en-Provence",
            DateDepart = new DateTime(2026, 1, 16, 11, 0, 0, DateTimeKind.Utc),
            DateArriveePrevue = new DateTime(2026, 1, 16, 13, 0, 0, DateTimeKind.Utc),
            DateArriveeReelle = new DateTime(2026, 1, 16, 15, 0, 0, DateTimeKind.Utc),
            NomPatient = "Lucienne Garcin",
            DateNaissancePatient = new DateOnly(1954, 3, 12),
            DestinataireId = laboratoire.Id
        };

        var t4 = new Transport
        {
            Reference = "TR-2026-0125",
            TypeProduit = "Dispositifs medicaux steriles",
            Statut = "EnCours",
            SiteDepart = "Entrepot Santelog Vitrolles",
            SiteArrivee = "Salon-de-Provence",
            DateDepart = new DateTime(2026, 1, 19, 7, 15, 0, DateTimeKind.Utc),
            DateArriveePrevue = new DateTime(2026, 1, 19, 10, 0, 0, DateTimeKind.Utc),
            DestinataireId = hopital.Id
        };

        var t5 = new Transport
        {
            Reference = "TR-2026-0128",
            TypeProduit = "Medicaments thermosensibles",
            Statut = "EnCours",
            SiteDepart = "Entrepot Santelog Vitrolles",
            SiteArrivee = "Marseille",
            DateDepart = new DateTime(2026, 1, 19, 8, 0, 0, DateTimeKind.Utc),
            DateArriveePrevue = new DateTime(2026, 1, 19, 11, 30, 0, DateTimeKind.Utc),
            DestinataireId = pharmacie.Id
        };

        var t6 = new Transport
        {
            Reference = "TR-2026-0131",
            TypeProduit = "Reactifs de laboratoire",
            Statut = "EnPreparation",
            SiteDepart = "Entrepot Santelog Vitrolles",
            SiteArrivee = "Aix-en-Provence",
            DateDepart = new DateTime(2026, 1, 21, 6, 0, 0, DateTimeKind.Utc),
            DateArriveePrevue = new DateTime(2026, 1, 21, 8, 45, 0, DateTimeKind.Utc),
            DestinataireId = laboratoire.Id
        };

        context.Transports.AddRange(t1, t2, t3, t4, t5, t6);
        context.SaveChanges();

        var releves = new List<ReleveTemperature>
        {
            new() { TransportId = t1.Id, HorodatageUtc = new DateTime(2026, 1, 12, 6, 30, 0, DateTimeKind.Utc), ValeurCelsius = 4.2, CapteurId = "CAP-104" },
            new() { TransportId = t1.Id, HorodatageUtc = new DateTime(2026, 1, 12, 7, 15, 0, DateTimeKind.Utc), ValeurCelsius = 4.6, CapteurId = "CAP-104" },
            new() { TransportId = t1.Id, HorodatageUtc = new DateTime(2026, 1, 12, 8, 0, 0, DateTimeKind.Utc), ValeurCelsius = 5.1, CapteurId = "CAP-104" },
            new() { TransportId = t1.Id, HorodatageUtc = new DateTime(2026, 1, 12, 8, 45, 0, DateTimeKind.Utc), ValeurCelsius = 4.9, CapteurId = "CAP-104" },
            new() { TransportId = t2.Id, HorodatageUtc = new DateTime(2026, 1, 14, 5, 45, 0, DateTimeKind.Utc), ValeurCelsius = 3.8, CapteurId = "CAP-117" },
            new() { TransportId = t2.Id, HorodatageUtc = new DateTime(2026, 1, 14, 6, 30, 0, DateTimeKind.Utc), ValeurCelsius = 4.1, CapteurId = "CAP-117" },
            new() { TransportId = t2.Id, HorodatageUtc = new DateTime(2026, 1, 14, 7, 15, 0, DateTimeKind.Utc), ValeurCelsius = 4.4, CapteurId = "CAP-117" },
            new() { TransportId = t2.Id, HorodatageUtc = new DateTime(2026, 1, 14, 8, 0, 0, DateTimeKind.Utc), ValeurCelsius = 4.0, CapteurId = "CAP-117" },
            new() { TransportId = t3.Id, HorodatageUtc = new DateTime(2026, 1, 16, 11, 0, 0, DateTimeKind.Utc), ValeurCelsius = 5.3, CapteurId = "CAP-092" },
            new() { TransportId = t3.Id, HorodatageUtc = new DateTime(2026, 1, 16, 11, 30, 0, DateTimeKind.Utc), ValeurCelsius = 6.8, CapteurId = "CAP-092" },
            new() { TransportId = t3.Id, HorodatageUtc = new DateTime(2026, 1, 16, 12, 0, 0, DateTimeKind.Utc), ValeurCelsius = 9.4, CapteurId = "CAP-092" },
            new() { TransportId = t3.Id, HorodatageUtc = new DateTime(2026, 1, 16, 12, 30, 0, DateTimeKind.Utc), ValeurCelsius = 11.2, CapteurId = "CAP-092" },
            new() { TransportId = t3.Id, HorodatageUtc = new DateTime(2026, 1, 16, 13, 0, 0, DateTimeKind.Utc), ValeurCelsius = 7.9, CapteurId = "CAP-092" },
            new() { TransportId = t4.Id, HorodatageUtc = new DateTime(2026, 1, 19, 7, 15, 0, DateTimeKind.Utc), ValeurCelsius = 4.5, CapteurId = "CAP-131" },
            new() { TransportId = t4.Id, HorodatageUtc = new DateTime(2026, 1, 19, 8, 0, 0, DateTimeKind.Utc), ValeurCelsius = 4.7, CapteurId = "CAP-131" },
            new() { TransportId = t4.Id, HorodatageUtc = new DateTime(2026, 1, 19, 8, 45, 0, DateTimeKind.Utc), ValeurCelsius = 4.3, CapteurId = "CAP-131" },
            new() { TransportId = t5.Id, HorodatageUtc = new DateTime(2026, 1, 19, 8, 0, 0, DateTimeKind.Utc), ValeurCelsius = 3.9, CapteurId = "CAP-058" },
            new() { TransportId = t5.Id, HorodatageUtc = new DateTime(2026, 1, 19, 8, 45, 0, DateTimeKind.Utc), ValeurCelsius = 4.2, CapteurId = "CAP-058" },
            new() { TransportId = t5.Id, HorodatageUtc = new DateTime(2026, 1, 19, 9, 30, 0, DateTimeKind.Utc), ValeurCelsius = 4.6, CapteurId = "CAP-058" },
            new() { TransportId = t5.Id, HorodatageUtc = new DateTime(2026, 1, 19, 10, 15, 0, DateTimeKind.Utc), ValeurCelsius = 4.8, CapteurId = "CAP-058" }
        };

        context.Releves.AddRange(releves);

        context.Utilisateurs.AddRange(
            new Utilisateur
            {
                NomUtilisateur = "evasseur",
                MotDePasse = "Santelog2019!",
                Role = "Responsable"
            },
            new Utilisateur
            {
                NomUtilisateur = "jmartin",
                MotDePasse = "transports",
                Role = "Livreur"
            },
            new Utilisateur
            {
                NomUtilisateur = "svc-export",
                MotDePasse = "Exp0rt-Nuit!2024",
                Role = "Admin"
            });

        context.SaveChanges();
    }
}
