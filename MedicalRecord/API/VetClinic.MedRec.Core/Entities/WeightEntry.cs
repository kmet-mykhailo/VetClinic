namespace VetClinic.MedRec.Core.Entities;

public class WeightEntry
{
    public int Id { get; set; }
    public Guid Key { get; set; }
    public int PetId { get; set; }
    public decimal Weight { get; set; }
    public byte WeightUnit { get; set; }
}