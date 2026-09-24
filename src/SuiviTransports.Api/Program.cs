using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using SuiviTransports.Api.Data;
using SuiviTransports.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Services.AddDbContext<SuiviTransportsContext>(options =>
    options
        .UseSqlite(builder.Configuration.GetConnectionString("SuiviTransports"))
        .UseLazyLoadingProxies());

builder.Services.AddScoped<TransportService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddSingleton<DestinataireService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SuiviTransportsContext>();
    DbSeeder.Seed(context);
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();
