using Microsoft.EntityFrameworkCore;
using SuiviTransports.Api.Data;
using SuiviTransports.Api.Models;

namespace SuiviTransports.Api.Services;

public class AuthService
{
    private readonly SuiviTransportsContext _context;

    public AuthService(SuiviTransportsContext context)
    {
        _context = context;
    }

    public async Task<Utilisateur?> ConnecterAsync(string nomUtilisateur, string motDePasse)
    {
        return await _context.Utilisateurs
            .FirstOrDefaultAsync(u => u.NomUtilisateur == nomUtilisateur && u.MotDePasse == motDePasse);
    }
}
