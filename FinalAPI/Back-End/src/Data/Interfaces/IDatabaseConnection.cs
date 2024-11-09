using System.Data;

public interface IDatabaseConnection
{
    Task<IDbConnection> InitializeConnection();
}