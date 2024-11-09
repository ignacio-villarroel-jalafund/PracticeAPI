using System.Reflection;
using DbUp;
using FirstAPi.Data.Interfaces;
using Microsoft.Extensions.Options;

namespace FirstAPi.Data.Concretes;

public class DbInitializer : IDbInitializer
{
    private readonly DatabaseOptions _options;

    public DbInitializer(IOptions<DatabaseOptions> options)
    {
        _options = options.Value;
    }

    public void InitializeDatabase()
    {
        EnsureDatabase.For.PostgresqlDatabase(_options.DefaultConnection);

        var dbUp = DeployChanges.To
        .PostgresqlDatabase(_options.DefaultConnection)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .WithTransaction()
        .LogToConsole()
        .Build();

        dbUp.PerformUpgrade();
    }
}