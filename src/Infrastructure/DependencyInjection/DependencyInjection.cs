using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScalableRestApi.Application.Interfaces;
using ScalableRestApi.Infrastructure.Persistence;
using ScalableRestApi.Infrastructure.Repositories;

namespace ScalableRestApi.Infrastructure.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    )
    //also takes IConfiguration as a parameter because it needs to
    // read the connection string from appsettings.json.

    {
        //Configure EF Core in Infrastructure
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        //This reads from your appsettings.json:
        //PartMeaningAddDbContext<ApplicationDbContext> register your DbContext with DI
        //options.UseMySql(...)tell EF Core to use MySQL as the database
        services.AddDbContext<ApplicationDbContext>(options =>
         options.UseMySql(
             connectionString,
             ServerVersion.AutoDetect(connectionString)
        ));
        services.AddScoped<IOrderRepository, MysqlOrderRepository>();
        //ServerVersion.AutoDetect(connectionString)connects 
        // to MySQL and detects the version automatically
        return services;
    }
}