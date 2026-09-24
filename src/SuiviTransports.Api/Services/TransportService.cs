using Microsoft.EntityFrameworkCore;
using SuiviTransports.Api.Data;
using SuiviTransports.Api.Models;

namespace SuiviTransports.Api.Services;

public class TransportService
{
    private readonly SuiviTransportsContext _context;

    public TransportService(SuiviTransportsContext context)
    {
        _context = context;
    }

    public async Task<List<Transport>> ObtenirTousAsync()
    {
        return await _context.Transports.ToListAsync();
    }

    public async Task<Transport?> ObtenirParIdAsync(int id)
    {
        return await _context.Transports.FindAsync(id);
    }

    public async Task<int> CreerAsync(Transport transport)
    {
        if (string.IsNullOrWhiteSpace(transport.Reference))
        {
            return -1;
        }

        var destinataire = await _context.Destinataires.FindAsync(transport.DestinataireId);
        if (destinataire == null)
        {
            return -2;
        }

        _context.Transports.Add(transport);
        await _context.SaveChangesAsync();
        return transport.Id;
    }

    public async Task<int> ChangerStatutAsync(int id, string statut)
    {
        var transport = await _context.Transports.FindAsync(id);
        if (transport == null)
        {
            return -1;
        }

        transport.Statut = statut;
        if (statut == "Livre")
        {
            transport.DateArriveeReelle = DateTime.Now;
        }

        await _context.SaveChangesAsync();
        return 0;
    }

    public int CalculerRetardMinutes(Transport transport)
    {
        var arrivee = transport.DateArriveeReelle ?? DateTime.Now;
        var ecart = arrivee - transport.DateArriveePrevue;
        return ecart.Minutes > 0 ? ecart.Minutes : 0;
    }

    public async Task<List<Transport>> RechercherParVilleAsync(string ville)
    {
        var sql = "SELECT * FROM Transports WHERE SiteArrivee LIKE '%" + ville + "%'";
        return await _context.Transports.FromSqlRaw(sql).ToListAsync();
    }

    public async Task<List<ReleveTemperature>> ObtenirRelevesAsync(int transportId)
    {
        return await _context.Releves
            .Where(r => r.TransportId == transportId)
            .OrderBy(r => r.HorodatageUtc)
            .ToListAsync();
    }

    public async Task AjouterReleveAsync(ReleveTemperature releve)
    {
        _context.Releves.Add(releve);
        await _context.SaveChangesAsync();
    }
}
