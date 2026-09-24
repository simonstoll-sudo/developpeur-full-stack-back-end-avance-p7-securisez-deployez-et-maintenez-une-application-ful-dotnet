# Guide pour les assistants IA

Ce document s'adresse aux assistants de programmation utilisés dans l'éditeur sur ce dépôt.

## Posture attendue

- **Aider à comprendre avant d'aider à écrire.** Expliquer le fonctionnement d'un mécanisme (EF Core, injection de dépendances, pipeline ASP.NET Core) avant de proposer du code.
- **Procéder par petites étapes.** Une modification à la fois, vérifiée par `dotnet build` et `dotnet test`, plutôt qu'une refonte massive.
- **Poser des questions avant de coder.** Le contexte (données de santé, contraintes de l'équipe) conditionne les choix techniques ; demander l'intention avant de produire une solution.
- **Ne pas décider à la place du développeur.** Proposer des options avec leurs compromis ; le diagnostic et les arbitrages lui appartiennent.

## Bonnes pratiques .NET sur ce projet

- Asynchrone de bout en bout : `async`/`await`, suffixe `Async`, jamais `.Result` ni `.Wait()`.
- Types nullables activés : traiter les avertissements de nullité, ne pas les désactiver.
- Validation par attributs de modèle et vérification de `ModelState` plutôt que par conditions dispersées.
- Injection par constructeur ; le choix de la durée de vie (`AddScoped`, `AddSingleton`, `AddTransient`) est une décision qui s'explique.
- Respecter l'organisation en couches du gabarit : `Controllers`, `Services`, `Models`, `Data`.

## Vigilance

- **Secrets** : ne jamais proposer d'écrire une clé, un mot de passe ou un jeton en dur dans le code ou la configuration versionnée. Utiliser des variables d'environnement ou un gestionnaire de secrets.
- **Données personnelles** : l'application traite des données liées à la santé ; ne jamais suggérer de journaliser ou d'exposer des données sensibles.
- **Code généré** : tout code proposé doit être relu, compris et testé avant d'être conservé. Encourager la vérification par les tests plutôt que la confiance.

## Architecture de ce projet

API REST ASP.NET Core dans `src/SuiviTransports.Api/` (contrôleurs, services injectés, entités EF Core, DbContext SQLite avec données de démarrage), projet de tests xUnit dans `tests/SuiviTransports.Tests/`, intégration continue dans `.github/workflows/`.

## Stack et versions

- .NET 10.0.12 (`net10.0`)
- Entity Framework Core 10.0.12 (SQLite, proxies de lazy loading)
- Swashbuckle.AspNetCore 10.2.3
- xUnit 2.9.3, coverlet.collector 10.0.1
