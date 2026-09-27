using Microsoft.Extensions.DependencyInjection;
using VetClinic.MedRec.App.Contracts.Services;
using VetClinic.MedRec.App.Services;

namespace VetClinic.MedRec.DI;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddMedRecServices(this IServiceCollection services)
    {
        services.AddScoped<IWeightEntryService, WeightEntryService>();
        return services;
    }
}