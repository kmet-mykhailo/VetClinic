namespace VetClinic.Api.WeightEntries.Models;

public record WeightEntryResponse(
    Guid Key, 
    decimal Weight, 
    byte WeightUnit
    );