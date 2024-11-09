using System.Data;
using Microsoft.Extensions.Options;
using Npgsql;

public class DatabaseConnection : IDatabaseConnection
{
    private readonly DatabaseOptions _options;

    public DatabaseConnection(IOptions<DatabaseOptions> options)
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