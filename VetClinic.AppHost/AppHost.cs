using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var medicalRecordApi = builder.AddProject<VetClinic_MedicalRecord_Api>("med-rec-api");
var authApi = builder.AddProject<VetClinic_Auth_Api>("auth-api");

builder.Build().Run();