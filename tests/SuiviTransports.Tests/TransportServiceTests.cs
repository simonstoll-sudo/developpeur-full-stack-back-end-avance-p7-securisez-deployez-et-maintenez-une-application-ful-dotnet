using SuiviTransports.Api.Models;
using Xunit;

namespace SuiviTransports.Tests;

public class TransportServiceTests
{
    [Fact]
    public void Transport_ProprietesAffectees_SontConservees()
    {
        var transport = new Transport
        {
            Reference = "TR-TEST-0001",
            TypeProduit = "Vaccins",
            SiteDepart = "Vitrolles",
            SiteArrivee = "Marseille"
        };

        Assert.Equal("TR-TEST-0001", transport.Reference);
        Assert.Equal("Vaccins", transport.TypeProduit);
        Assert.Equal("Vitrolles", transport.SiteDepart);
        Assert.Equal("Marseille", transport.SiteArrivee);
    }

    [Fact]
    public void Transport_StatutParDefaut_EstEnPreparation()
    {
        var transport = new Transport();

        Assert.Equal("EnPreparation", transport.Statut);
    }
}
