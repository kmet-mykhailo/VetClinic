using Scalar.AspNetCore;
using VetClinic.MedRec.App.Contracts.Queries;
using VetClinic.MedRec.App.Contracts.Services;
using VetClinic.MedRec.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.AddServiceDefaults();
builder.Services.AddMedRecServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
        options.WithTitle("My .NET 10 API")
            .WithTheme(ScalarTheme.Moon) // Use themes like Dark, Moon, Purple, etc.
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
    );
}

app.MapDefaultEndpoints();
app.MapGet("/", () => "Hello World!");
app.MapGet("/weights", async (IWeightEntryService service) =>
    await service.GetWeightEntries(new GetWeightsQuery(Guid.Empty, Guid.Empty)));

app.Run();