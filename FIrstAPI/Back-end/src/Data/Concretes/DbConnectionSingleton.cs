using System.Data;
using FirstAPi.Data.Interfaces;
using Microsoft.Extensions.Options;
using Npgsql;

namespace FirstAPi.Data.Concretes;

public class DbConnectionSingleton : IDbConnectionSingleton
{
    private readonly DatabaseOptions _options;

    public DbConnectionSingleton(IOptions<DatabaseOptions> options)
    {
        _options = options.Value;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_options.DefaultConnection);
        await connection.OpenAsync();
        return connection;
    }
}
