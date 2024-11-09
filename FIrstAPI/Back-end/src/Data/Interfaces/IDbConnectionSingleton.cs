using System.Data;

namespace FirstAPi.Data.Interfaces;

public interface IDbConnectionSingleton
{
    Task<IDbConnection> CreateConnectionAsync();
}