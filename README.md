# Suivi Transports — API de traçabilité des transports de produits de santé

API interne de l'équipe Suivi Transports (Santélog). Elle trace les transports de produits de santé — médicaments, dispositifs médicaux, échantillons biologiques — entre l'entrepôt et les destinataires, avec les relevés de température remontés par les capteurs embarqués.

L'interface web de suivi (écran de suivi des transports, tableau de bord) est maintenue par une autre équipe et consomme cette API.

## Prérequis

- [SDK .NET 10](https://dotnet.microsoft.com/download) (10.0.100 ou version ultérieure)
- Git

Aucune base de données à installer : l'application utilise SQLite (fichier local créé au premier lancement, avec des données de démarrage).

## Installation

```bash
git clone <url-du-depot>
cd <dossier-du-depot>
dotnet restore
```

## Lancement

```bash
dotnet run --project src/SuiviTransports.Api
```

Le profil de lancement (`src/SuiviTransports.Api/Properties/launchSettings.json`) démarre l'API en environnement `Development` sur `http://localhost:5080`. La documentation Swagger est disponible sur `http://localhost:5080/swagger`.

Les variables d'environnement attendues sont listées dans `.env.example`.

## Tests

```bash
dotnet test
```

## Stack technique

- C# / .NET 10.0.12
- ASP.NET Core (API REST)
- Entity Framework Core 10.0.12 (SQLite, proxies de lazy loading)
- Swashbuckle (Swagger)
- xUnit (tests)

## Structure du projet

```
.
├── src/SuiviTransports.Api/
│   ├── Controllers/     # points d'entrée HTTP
│   ├── Services/        # règles métier et accès aux données
│   ├── Models/          # entités du domaine
│   ├── Data/            # DbContext EF Core et données de démarrage
│   └── Program.cs       # démarrage et injection de dépendances
├── tests/SuiviTransports.Tests/
├── docs/                # documentation interne de l'équipe
└── .github/workflows/   # intégration continue
```

## Points d'entrée de l'API

| Méthode | Route | Description |
| --- | --- | --- |
| GET | `/api/transports` | Liste des transports |
| GET | `/api/transports/{id}` | Détail d'un transport |
| POST | `/api/transports` | Création d'un transport |
| PUT | `/api/transports/{id}/statut` | Changement de statut |
| GET | `/api/transports/{id}/retard` | Retard d'un transport (en minutes) |
| GET | `/api/transports/recherche?ville=` | Recherche par ville d'arrivée |
| GET | `/api/transports/{id}/releves` | Relevés de température d'un transport |
| POST | `/api/transports/{id}/releves` | Ajout d'un relevé |
| GET | `/api/destinataires` | Liste des destinataires |
| GET | `/api/destinataires/{id}` | Détail d'un destinataire |
| POST | `/api/destinataires` | Création d'un destinataire |
| POST | `/api/auth/login` | Connexion |

## Scripts utiles

| Commande | Effet |
| --- | --- |
| `dotnet build` | Compile la solution |
| `dotnet test` | Exécute la suite de tests |
| `dotnet run --project src/SuiviTransports.Api` | Lance l'API |

## Licence

Projet interne Santélog. Tous droits réservés.
