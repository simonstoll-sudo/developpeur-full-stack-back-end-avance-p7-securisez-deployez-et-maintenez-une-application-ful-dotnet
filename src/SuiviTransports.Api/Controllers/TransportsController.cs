using Microsoft.AspNetCore.Mvc;
using SuiviTransports.Api.Models;
using SuiviTransports.Api.Services;

namespace SuiviTransports.Api.Controllers;

[ApiController]
[Route("api/transports")]
public class TransportsController : ControllerBase
{
    private readonly TransportService _transportService;
    private readonly ILogger<TransportsController> _logger;

    public TransportsController(TransportService transportService, ILogger<TransportsController> logger)
    {
        _transportService = transportService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenirTous()
    {
        var transports = await _transportService.ObtenirTousAsync();
        return Ok(transports);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> ObtenirParId(int id)
    {
        var transport = await _transportService.ObtenirParIdAsync(id);
        if (transport == null)
        {
            return NotFound();
        }

        return Ok(transport);
    }

    [HttpPost]
    public async Task<IActionResult> Creer(Transport transport)
    {
        _logger.LogInformation("Creation transport : {Transport}", System.Text.Json.JsonSerializer.Serialize(transport));

        try
        {
            if (transport.Reference == null || transport.Reference == "")
            {
                return BadRequest("reference manquante");
            }

            var resultat = await _transportService.CreerAsync(transport);
            if (resultat == -1)
            {
                return BadRequest("reference manquante");
            }
            if (resultat == -2)
            {
                return BadRequest("destinataire inconnu");
            }

            return Ok(resultat);
        }
        catch (Exception ex)
        {
            _logger.LogInformation("Erreur creation transport : " + ex.Message);
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}/statut")]
    public async Task<IActionResult> ChangerStatut(int id, [FromBody] string statut)
    {
        var resultat = await _transportService.ChangerStatutAsync(id, statut);
        if (resultat == -1)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpGet("{id}/retard")]
    public async Task<IActionResult> ObtenirRetard(int id)
    {
        var transport = await _transportService.ObtenirParIdAsync(id);
        if (transport == null)
        {
            return NotFound();
        }

        return Ok(new
        {
            transport.Reference,
            RetardMinutes = _transportService.CalculerRetardMinutes(transport)
        });
    }

    [HttpGet("recherche")]
    public async Task<IActionResult> Rechercher(string ville)
    {
        var transports = await _transportService.RechercherParVilleAsync(ville);
        return Ok(transports);
    }

    [HttpGet("{id}/releves")]
    public async Task<IActionResult> ObtenirReleves(int id)
    {
        var releves = await _transportService.ObtenirRelevesAsync(id);
        return Ok(releves);
    }

    [HttpPost("{id}/releves")]
    public async Task<IActionResult> AjouterReleve(int id, ReleveTemperature releve)
    {
        _logger.LogInformation("Nouveau releve : {Releve}", System.Text.Json.JsonSerializer.Serialize(releve));

        releve.TransportId = id;
        await _transportService.AjouterReleveAsync(releve);
        return Ok(releve);
    }
}
