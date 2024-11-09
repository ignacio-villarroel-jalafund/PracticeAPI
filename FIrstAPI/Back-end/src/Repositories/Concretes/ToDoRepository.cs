using Dapper;
using FirstAPi.Data.Interfaces;
using FirstAPi.Domain.Entities;
using FirstAPi.Repositories.Interfaces;

namespace FirstAPi.Repositories.Concretes;

public class ToDoRepository : IToDoRepository
{
    private readonly IDbConnectionSingleton _dbConnection;

    public ToDoRepository(IDbConnectionSingleton dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public async Task<ToDo?> CreateAsync(ToDo item)
    {
        const string query = @"
            INSERT INTO ToDo (Title, Description, IsCompleted)
            VALUES (@Title, @Description, @IsCompleted)
            RETURNING Title, Description, IsCompleted";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QuerySingleOrDefaultAsync<ToDo>(query, item);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string query = @"DELETE FROM ToDo Where Id = @Id";

        using var connection = await _dbConnection.CreateConnectionAsync();
        var affectedRows = await connection.ExecuteAsync(query, new { Id = id });
        return affectedRows > 0;
    }

    public async Task<IEnumerable<ToDo>> GetAllAsync()
    {
        const string query = @"SELECT * FROM ToDo";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryAsync<ToDo>(query);
    }

    public async Task<ToDo?> GetByIdAsync(int id)
    {
        const string query = @"SELECT * FROM ToDo WHERE Id = @Id";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryFirstOrDefaultAsync<ToDo>(query, new {Id = id});
    }

    public async Task<ToDo?> UpdateAsync(ToDo item)
    {
        const string query = @"
            UPDATE ToDo 
            SET Title = @Title, Description = @Description, IsCompleted = @IsCompleted 
            WHERE Id = @Id
            RETURNING Id, Title, Description, IsCompleted";

        using var connection = await _dbConnection.CreateConnectionAsync();
        return await connection.QueryFirstOrDefaultAsync<ToDo>(query, item);
    }
}
