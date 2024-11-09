using FirstAPi.Data;
using FirstAPi.Data.Concretes;
using FirstAPi.Data.Interfaces;
using FirstAPi.Repositories.Concretes;
using FirstAPi.Repositories.Interfaces;
using FirstAPi.Services.Concretes;
using FirstAPi.Services.Interfaces;

namespace FirstAPi.Infraestructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration)
            .AddReposositories()
            .AddServices();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.ConnectionStrings));
        services.AddSingleton<IDbConnectionSingleton, DbConnectionSingleton>();
        services.AddScoped<IDbInitializer, DbInitializer>();

        return services;
    }

    private static IServiceCollection AddReposositories(this IServiceCollection services)
    {
        services.AddScoped<IToDoRepository, ToDoRepository>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IToDoService, ToDoService>();

        return services;
    }
}