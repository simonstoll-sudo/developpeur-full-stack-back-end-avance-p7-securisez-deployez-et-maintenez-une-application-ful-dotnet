using Microsoft.AspNetCore.Mvc;
using SuiviTransports.Api.Services;

namespace SuiviTransports.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(AuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public class LoginRequest
    {
        public string NomUtilisateur { get; set; } = string.Empty;

        public string MotDePasse { get; set; } = string.Empty;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        _logger.LogInformation("Tentative de connexion : {NomUtilisateur} / {MotDePasse}", request.NomUtilisateur, request.MotDePasse);

        var utilisateur = await _authService.ConnecterAsync(request.NomUtilisateur, request.MotDePasse);
        if (utilisateur == null)
        {
            return Unauthorized();
        }

        return Ok(utilisateur);
    }
}
