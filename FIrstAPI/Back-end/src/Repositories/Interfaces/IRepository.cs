namespace FirstAPi.Repositories.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T?> CreateAsync(T item);
    Task<T?> UpdateAsync(T item);
    Task<bool> DeleteAsync(int id);
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}