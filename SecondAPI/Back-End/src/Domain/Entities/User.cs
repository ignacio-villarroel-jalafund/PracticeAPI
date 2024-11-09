public class User
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string? LastName { get; set; }
    public required string Ocupation { get; set; }
}