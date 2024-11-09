public record UserDTO
(
    Guid Id,
    string Name,
    string LastName,
    string Ocupation
)
{
    public User ToDomain()
    {
        return new User
        {
            Id = Id,
            Name = Name,
            LastName = LastName,
            Ocupation = Ocupation
        };
    }
}