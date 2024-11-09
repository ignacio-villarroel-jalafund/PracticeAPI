public interface IRepository<T>
{
    Task<T?> CreateAsync(T item);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<bool> DeleteAsync(Guid id);
    Task<T?> UpdateAsync(T item);
}