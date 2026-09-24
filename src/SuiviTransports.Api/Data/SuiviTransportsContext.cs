using Microsoft.EntityFrameworkCore;
using SuiviTransports.Api.Models;

namespace SuiviTransports.Api.Data;

public class SuiviTransportsContext : DbContext
{
    public SuiviTransportsContext(DbContextOptions<SuiviTransportsContext> options)
        : base(options)
    {
    }

    public DbSet<Transport> Transports => Set<Transport>();

    public DbSet<ReleveTemperature> Releves => Set<ReleveTemperature>();

    public DbSet<Destinataire> Destinataires => Set<Destinataire>();

    public DbSet<Utilisateur> Utilisateurs => Set<Utilisateur>();
}
