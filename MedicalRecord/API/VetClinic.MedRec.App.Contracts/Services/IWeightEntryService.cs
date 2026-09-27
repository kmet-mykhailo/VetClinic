using VetClinic.MedRec.App.Contracts.Queries;
using VetClinic.MedRec.App.Contracts.Results;

namespace VetClinic.MedRec.App.Contracts.Services;

public interface IWeightEntryService
{
    Task<List<WeightEntryResult>> GetWeightEntries(GetWeightsQuery  query);
}