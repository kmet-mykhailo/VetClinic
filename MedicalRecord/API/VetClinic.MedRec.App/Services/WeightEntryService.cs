using VetClinic.MedRec.App.Contracts.Queries;
using VetClinic.MedRec.App.Contracts.Results;
using VetClinic.MedRec.App.Contracts.Services;

namespace VetClinic.MedRec.App.Services;

public class WeightEntryService: IWeightEntryService
{
    public Task<List<WeightEntryResult>> GetWeightEntries(GetWeightsQuery query)
    {
        return Task.FromResult(new List<WeightEntryResult>()
        {
            new(Guid.NewGuid(), 101, 1),
            new(Guid.NewGuid(), 100, 1),
            new(Guid.NewGuid(), 98, 1)
        });
    }
}