public interface IUserService
{
    Task<User> CreateUserAsync(UserDTO user);
    Task<User?> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<User>> GetAllUserAsync();
    Task<User> UpdateUserAsync(Guid userId, UserDTO user);
    Task<bool> DeleteUserAsync(Guid userId);
}