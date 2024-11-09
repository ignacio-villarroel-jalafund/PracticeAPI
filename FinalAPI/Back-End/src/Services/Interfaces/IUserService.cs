public interface IUserService 
{
    Task<User> CreateUser(RequestUserDTO item);
    Task<User?> GetUserById(Guid id);
    Task<List<User>> GetAllUsers();
    Task<User?> UpdateUser(Guid id, RequestUserDTO item);
    Task<bool> DeleteUser(Guid id);
}