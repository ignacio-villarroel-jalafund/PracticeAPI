
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> CreateUser(RequestUserDTO item)
    {
        var newUser = new User{
            Id = Guid.NewGuid(),
            Name = item.Name,
            LastName = item.LastName,
            Occupation = item.Occupation
        };

        var result = await _userRepository.Create(newUser);
        return result;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var existingUser = await _userRepository.GetById(id);
        if (existingUser == null)
        {
            throw new ArgumentException("User not found");
        }
        var result = await _userRepository.Delete(existingUser.Id);
        return result;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<User?> UpdateUser(Guid id, RequestUserDTO item)
    {
        var existingUser = await _userRepository.GetById(id);
        if (existingUser == null)
        {
            throw new ArgumentException("User not found");
        }
        existingUser.Name = item.Name;
        existingUser.LastName = item.LastName;
        existingUser.Occupation = item.Occupation;

        return await _userRepository.Update(existingUser);
    }
}
