using ConsultasApp.Application.Interfaces;
using ConsultasApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultasApp.Application.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IPacienteAppService, PacienteAppService>();
        services.AddScoped<IMedicoAppService, MedicoAppService>();
        services.AddScoped<IConsultaAppService, ConsultaAppService>();
        services.AddScoped<IEnderecoAppService, EnderecoAppService>();
        services.AddHttpClient<ViaCepService>();
        return services;
    }
}