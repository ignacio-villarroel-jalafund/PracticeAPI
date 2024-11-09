
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUserAsync(UserDTO user)
    {
        var newUser = new User
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            LastName = user.LastName,
            Ocupation = user.Ocupation
        };

        var result = await _userRepository.CreateAsync(newUser);

        if (result == null)
        {
            throw new ArgumentException("Error Creating User");
        }

        return newUser;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var existingUser = await _userRepository.GetByIdAsync(userId);

        if (existingUser == null)
        {
            throw new ArgumentException("User does not exist");
        }

        return await _userRepository.DeleteAsync(existingUser.Id);
    }

    public async Task<IEnumerable<User>> GetAllUserAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User?> GetUserByIdAsync(Guid userId)
    {
        return await _userRepository.GetByIdAsync(userId);
    }

    public async Task<User?> UpdateUserAsync(Guid userId, UserDTO user)
    {
        var existingUser = await _userRepository.GetByIdAsync(userId);

        if (existingUser == null)
        {
            throw new ArgumentException("User does not exist");
        }
        existingUser.Name = user.Name;
        existingUser.LastName = user.LastName;
        existingUser.Ocupation = user.Ocupation;

        return await _userRepository.UpdateAsync(existingUser);
    }
}
