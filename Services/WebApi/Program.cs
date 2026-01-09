using Microsoft.OpenApi;
using Spectre.Console;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Minimal API Demo",
        Version = "v1",
        Description = ".NET Core 10 Minimal API with Swagger"
    });
});

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Minimal API Demo v1");
    });
}

app.UseHttpsRedirection();

app.MapHealthChecks("/healthz");

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast = Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast");

AnsiConsole.MarkupLine("[green]✓ Build completed successfully[/]");
try
{
    AnsiConsole.MarkupLine("[#FFA500]⚠[/] [yellow]Starting application[/]");
    await app.RunAsync();
}
catch (Exception e)
{
    AnsiConsole.MarkupLine("[red]✗ Application start failed[/]");
    AnsiConsole.MarkupLine($"[red]{e.Message}[/]");
}
