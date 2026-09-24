using Microsoft.AspNetCore.Mvc;
using SuiviTransports.Api.Data;
using SuiviTransports.Api.Models;
using SuiviTransports.Api.Services;

namespace SuiviTransports.Api.Controllers;

[ApiController]
[Route("api/destinataires")]
public class DestinatairesController : ControllerBase
{
    private readonly DestinataireService _destinataireService;
    private readonly SuiviTransportsContext _context;
    private readonly ILogger<DestinatairesController> _logger;

    public DestinatairesController(DestinataireService destinataireService, SuiviTransportsContext context, ILogger<DestinatairesController> logger)
    {
        _destinataireService = destinataireService;
        _context = context;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenirTous()
    {
        var destinataires = await _destinataireService.ObtenirTousAsync();
        return Ok(destinataires);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenirParId(int id)
    {
        var destinataire = await _destinataireService.ObtenirParIdAsync(id);
        if (destinataire == null)
        {
            return NotFound();
        }

        var nombreTransports = destinataire.Transports.Count;

        return Ok(new
        {
            destinataire.Id,
            destinataire.Nom,
            destinataire.Type,
            destinataire.Adresse,
            destinataire.Email,
            destinataire.Telephone,
            NombreTransports = nombreTransports,
            Transports = destinataire.Transports
        });
    }

    [HttpPost]
    public async Task<IActionResult> Creer(Destinataire destinataire)
    {
        _logger.LogInformation("Creation destinataire : {Destinataire}", System.Text.Json.JsonSerializer.Serialize(destinataire));

        _context.Destinataires.Add(destinataire);
        await _context.SaveChangesAsync();
        return Ok(destinataire);
    }
}
