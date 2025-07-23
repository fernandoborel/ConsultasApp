using ConsultasApp.Domain.Interfaces.Repositories;
using ConsultasApp.Infra.Data.Contexts;
using ConsultasApp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultasApp.Infra.Data.Extensions;

public static class EntityFrameworkExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DBO_CONSULTASAPP"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}