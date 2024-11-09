public record ResponseUser
(
    Guid Id,
    string Name,
    string? LastName,
    string Ocupation
)
{
    public static ResponseUser FromDomain(User user)
    {
        return new ResponseUser
        (
            user.Id,
            user.Name,
            user.LastName,
            user.Ocupation
        );
    }
}