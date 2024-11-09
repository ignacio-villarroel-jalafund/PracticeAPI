public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration).AddRepostiories().AddServices();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.ConnectionStrings));
        services.AddSingleton<IDbConnectionSingleton, DbConnectionSingleton>();
        services.AddScoped<IDbInitializer, DbInitializer>();

        return services;
    }

    private static IServiceCollection AddRepostiories(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IUserService, UserService>();

        return services;
    }
}
