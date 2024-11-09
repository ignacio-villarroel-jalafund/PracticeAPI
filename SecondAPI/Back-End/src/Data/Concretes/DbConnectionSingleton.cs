using System.Data;
using DbUp;
using Microsoft.Extensions.Options;
using Npgsql;

public class DbConnectionSingleton : IDbConnectionSingleton
{
    private readonly DatabaseOptions _options;

    public DbConnectionSingleton(IOptions<DatabaseOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IDbConnection> InitializeConnection()
    {
        var connection = new NpgsqlConnection(_options.DefaultConnection);
        await connection.OpenAsync();
        return connection;
    }
}
