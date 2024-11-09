
using System.Data;
using Dapper;

public class UserRepositoryDb : IUserRepository
{
    private readonly IDatabaseConnection _dbConnection;

    public UserRepositoryDb(IDatabaseConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<User?> Create(User item)
    {
        const string query = @"
        INSERT INTO Users (Id, Name, LastName, Occupation) 
        VALUES (@Id, @Name, @LastName, @Occupation) 
        RETURNING (@Id, @Name, @LastName, @Occupation)";

        using var connection = await _dbConnection.InitializeConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(query, item);
    }

    public async Task<bool> Delete(Guid id)
    {
        const string query = "DELETE FROM Users WHERE Id = @Id";

        using var connection = await _dbConnection.InitializeConnection();
        var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<List<User>> GetAll()
    {
        const string query = "SELECT * FROM Users";


        using var connection = await _dbConnection.InitializeConnection();
        var result = await connection.QueryAsync<User>(query);
        var array = result.AsList();
        return array;
    }

    public async Task<User?> GetById(Guid id)
    {
        const string query = "SELECT * FROM Users WHERE Id = @Id";


        using var connection = await _dbConnection.InitializeConnection();
        return await connection.QuerySingleOrDefaultAsync<User>(query, new { Id = id });
    }

    public async Task<User?> Update(User item)
    {
        const string query = @"
        UPDATE Users Id = @Id, Name = @Name, LastName = @LastName, Occupation = @Occupation 
        WHERE Id = @Id
        RETURNING (@Id, @Name, @LastName, @Occupation)";

        using var connection = await _dbConnection.InitializeConnection();
        return await connection.QueryFirstOrDefaultAsync<User>(query, item);
    }
}