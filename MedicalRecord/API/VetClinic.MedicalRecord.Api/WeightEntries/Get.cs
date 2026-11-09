using VetClinic.Api.Infrastructure;
using VetClinic.Api.WeightEntries.Models;
using VetClinic.MedRec.App.Contracts.Queries;
using VetClinic.MedRec.App.Contracts.Services;

namespace VetClinic.Api.WeightEntries;

/// <summary>
/// Returns pet weight entries
/// </summary>
public class GetPetWeightEntriesEndpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/medical-record/{medicalRecordId:guid}/weight-entries", HandleAsync);
    }

    private static async Task<IResult> HandleAsync(IWeightEntryService  service, Guid medicalRecordId)
    {
        var query = new GetWeightsQuery(medicalRecordId);
        var weightEntries = await service.GetWeightEntries(query);
        return Results.Ok(weightEntries);
    }
}