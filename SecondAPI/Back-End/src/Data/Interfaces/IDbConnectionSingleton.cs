using System.Data;

public interface IDbConnectionSingleton {
    Task<IDbConnection> InitializeConnection();
}