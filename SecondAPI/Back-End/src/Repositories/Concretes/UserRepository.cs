
using Dapper;

public class UserRepository : IUserRepository
{
    private readonly IDbConnectionSingleton _dbConnection;

    public UserRepository(IDbConnectionSingleton dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<User?> CreateAsync(User item)
    {
        const string query = @"
        INSERT INTO Users (Id, Name, LastName, Ocupation) 
        VALUES (@Id, @Name, @LastName, @Ocupation) 
        RETURNING (@Id, @Name, @LastName, @Ocupation)";

        using var connection = await _dbConnection.InitializeConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(query, item);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        const string query = "DELETE FROM Users WHERE @Id = Id";

        using var connection = await _dbConnection.InitializeConnection();

        var affectedRows = await connection.ExecuteAsync(query, new { Id = id });

        return affectedRows > 0;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        const string query = "SELECT * FROM Users";

        using var connection = await _dbConnection.InitializeConnection();
        return await connection.QueryAsync<User>(query);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        const string query = "SELECT * FROM Users WHERE @Id = Id";

        using var connection = await _dbConnection.InitializeConnection();
        return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<User?> UpdateAsync(User item)
    {
        const string query = @"
        UPDATE Users 
        SET Name = @Name, LastName = @LastName, Ocupation = @Ocupation 
        WHERE @Id = Id
        RETURNING (@Id, @Name, @LastName, @Ocupation)
        ";

        using var connection = await _dbConnection.InitializeConnection();

        return await connection.QuerySingleOrDefaultAsync<User>(query, item);
    }
}