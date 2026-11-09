using System.Reflection;

namespace VetClinic.Api.Infrastructure;

public static class EndpointExtensions
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(x=>typeof(IEndpoint).IsAssignableFrom(x) && !x.IsInterface);

        foreach (var endpoint in endpoints)
        {
            var instance = (IEndpoint)Activator.CreateInstance(endpoint)!;
            instance.MapEndpoints(app);
        }
    }
}