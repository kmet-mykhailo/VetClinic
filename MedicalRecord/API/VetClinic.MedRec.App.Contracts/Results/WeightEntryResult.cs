namespace VetClinic.MedRec.App.Contracts.Results;

public class WeightEntryResult
{
    public Guid Key { get; set; }
    public int PetId { get; set; }
    public decimal Weight { get; set; }
    public byte WeightUnit { get; set; }
}