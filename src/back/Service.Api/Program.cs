using Application.Interface;
using Application.Main;
using Domain.Core;
using Domain.Interface;
using Infraestructure.Interface;
using Infraestructure.Repository;
using Infrastructure.Data;
using Transversal.Common;
using Transversal.Logging;

var builder = WebApplication.CreateBuilder(args);

// Agregar servicios al contenedor.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Contenedor de dependencias
builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();
builder.Services.AddSingleton<IAppLogger, LoggerAdapter>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();
builder.Services.AddScoped<IExchangeRateDomain, ExchangeRateDomain>();
builder.Services.AddScoped<IExchangeRateApplication, ExchangeRateApplication>();


var app = builder.Build();

// Configurar el pipeline de solicitudes HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/exchangerates", async (IExchangeRateApplication exchangeRateApplication, HttpResponse httpResponse) =>
{
    var response = await exchangeRateApplication.GetAll();
    httpResponse.StatusCode = response.StatusCode;
    await httpResponse.WriteAsJsonAsync(response);
})
.WithName("GetAllExchangeRates")
.WithOpenApi();



app.Run();
