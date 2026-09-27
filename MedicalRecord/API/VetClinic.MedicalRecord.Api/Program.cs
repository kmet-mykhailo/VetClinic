using VetClinic.MedRec.App.Contracts.Queries;
using VetClinic.MedRec.App.Contracts.Services;
using VetClinic.MedRec.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMedRecServices();
builder.AddServiceDefaults();

var app = builder.Build();

app.MapDefaultEndpoints();
app.MapGet("/", () => "Hello World!");
app.MapGet("/weights", async (IWeightEntryService service) =>
    await service.GetWeightEntries(new GetWeightsQuery(Guid.Empty, Guid.Empty)));

app.Run();