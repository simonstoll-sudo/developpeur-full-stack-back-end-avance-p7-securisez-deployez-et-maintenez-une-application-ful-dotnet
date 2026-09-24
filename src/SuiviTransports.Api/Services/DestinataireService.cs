using Microsoft.Extensions.DependencyInjection;
using SuiviTransports.Api.Data;
using SuiviTransports.Api.Models;

namespace SuiviTransports.Api.Services;

public class DestinataireService
{
    private static List<Destinataire>? _cache;

    private readonly IServiceProvider _serviceProvider;

    public DestinataireService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task<List<Destinataire>> ObtenirTousAsync()
    {
        if (_cache == null)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<SuiviTransportsContext>();
            _cache = context.Destinataires.ToList();
        }

        return await Task.FromResult(_cache);
    }

    public async Task<Destinataire?> ObtenirParIdAsync(int id)
    {
        var tous = await ObtenirTousAsync();
        return tous.FirstOrDefault(d => d.Id == id);
    }
}
