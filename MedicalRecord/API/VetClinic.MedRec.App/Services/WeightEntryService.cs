using VetClinic.MedRec.App.Contracts.Queries;
using VetClinic.MedRec.App.Contracts.Results;
using VetClinic.MedRec.App.Contracts.Services;

namespace VetClinic.MedRec.App.Services;

public class WeightEntryService: IWeightEntryService
{
    public Task<List<WeightEntryResult>> GetWeightEntries(GetWeightsQuery query)
    {
        return Task.FromResult(new List<WeightEntryResult> { new WeightEntryResult
        {
            Weight = 10,
            WeightUnit = 1,
            Key = Guid.NewGuid()
        } });
    }
}