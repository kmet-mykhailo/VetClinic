namespace VetClinic.MedRec.App.Contracts.Commands;

public record CreateWeightEntryCommand(Guid PetId, decimal Weight, byte WeightUnit);