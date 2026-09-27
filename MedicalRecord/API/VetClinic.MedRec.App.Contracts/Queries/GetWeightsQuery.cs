namespace VetClinic.MedRec.App.Contracts.Queries;

public record GetWeightsQuery(Guid PetKey, Guid ClinicKey);