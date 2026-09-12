namespace VetClinic.MedRec.App.Contracts.Queries;

public record GetWeightQuery(Guid PetId, Guid ClinicId);