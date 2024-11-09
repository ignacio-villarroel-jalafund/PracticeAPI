public class DatabaseOptions
{
    public const string ConnectionStrings = nameof(ConnectionStrings);
    public string? DefaultConnection { get; set; }
    public const string DataStorageType = nameof(DataStorageType);
    public bool UseInMemoryStorage { get; set; }
}