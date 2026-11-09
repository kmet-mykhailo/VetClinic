using System.Reflection;
using Scalar.AspNetCore;
using VetClinic.Api.Infrastructure;
using VetClinic.MedRec.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddMedRecServices();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
        options.WithTitle("Medical Record .NET 10 API")
            .WithTheme(ScalarTheme.Moon) // Use themes like Dark, Moon, Purple, etc.
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
    );
}

app.MapDefaultEndpoints();
app.MapGet("/", () => "ready");

app.MapEndpoints();
app.Run();
