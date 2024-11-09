
public class UserRepositoryMemory : IUserRepository
{
    private readonly List<User> _users;

    public UserRepositoryMemory()
    {
        _users = new List<User>();
    }
    public Task<User?> Create(User item)
    {
        _users.Add(item);
        return Task.FromResult(item);
    }

    public Task<bool> Delete(Guid id)
    {
        var existingUser = _users.FirstOrDefault(user => user.Id.Equals(id));
        if (existingUser != null)
        {
            _users.Remove(existingUser);
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }

    public Task<List<User>> GetAll()
    {
        return Task.FromResult(_users);
    }

    public Task<User?> GetById(Guid id)
    {
        var existingUser = _users.FirstOrDefault(user => user.Id.Equals(id));
        return Task.FromResult(existingUser);
    }

    public Task<User?> Update(User item)
    {
        var existingUser = _users.FirstOrDefault(user => user.Id.Equals(item.Id));
        if (existingUser == null) return Task.FromResult(existingUser);
        existingUser.Name = item.Name;
        existingUser.LastName = item.LastName;
        existingUser.Occupation = item.Occupation;
        return Task.FromResult(existingUser);
    }
}
