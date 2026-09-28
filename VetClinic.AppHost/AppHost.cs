using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var medicalRecordApi = builder.AddProject<VetClinic_MedicalRecord_Api>("MedRec-Api");

var medicalRecordPageUi =
    builder.AddExecutable(
            "MedRecPage-UI",
            "npm",
            "../MedicalRecord/FrontEnds/med-rec-page",
            "start")
        .WithHttpEndpoint(port: 4200, env: "PORT")
        .WithReference(medicalRecordApi);

var authApi = builder.AddProject<VetClinic_Auth_Api>("Auth-API");

builder.Build().Run();