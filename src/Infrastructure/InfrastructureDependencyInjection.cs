using Application.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureDependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
    {
        var settings = config.GetSection("GoogleSheets").Get<GoogleSheetSettings>();
           
        services.AddSingleton(settings);

        services.AddScoped<IGoogleSheetService>(googleService =>
            new GoogleSheetService(settings.CredentialsPath, settings.SpreadsheetId));
        return services;
    }
}
