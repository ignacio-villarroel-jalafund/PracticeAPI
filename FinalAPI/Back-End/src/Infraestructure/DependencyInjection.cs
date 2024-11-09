public static class DependencyInjection
{
    public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration).AddServices();

        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.ConnectionStrings));
        services.Configure<DatabaseOptions>(configuration.GetSection(DatabaseOptions.DataStorageType));
        var databaseOptions = configuration.GetSection("DataStorageType").Get<DatabaseOptions>();

        if (databaseOptions.UseInMemoryStorage)
        {
            services.AddSingleton<IUserRepository, UserRepositoryMemory>();
        }
        else
        {
            services.AddSingleton<IDatabaseConnection, DatabaseConnection>();
            services.AddScoped<IUserRepository, UserRepositoryDb>();
        }

        services.AddScoped<IDbInitializer, DbInitializer>();

        return services;
    }

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        return services;
    }

}