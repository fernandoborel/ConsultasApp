using ConsultasApp.Domain.Interfaces.Services;
using ConsultasApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultasApp.Domain.Extensions;

public static class DomainServicesExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IConsultaDomainService, ConsultasDomainService>();
        services.AddScoped<IPacienteDomainService, PacienteDomainService>();
        services.AddScoped<IMedicoDomainService, MedicoDomainService>();
        services.AddScoped<IEnderecoDomainService, EnderecoDomainService>();
        
        return services;
    }
}