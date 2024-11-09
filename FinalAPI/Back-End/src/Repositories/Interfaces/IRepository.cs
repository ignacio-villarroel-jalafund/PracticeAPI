public interface IRepository<T>
{
    Task<T?> Create(T item);
    Task<T?> GetById(Guid id);
    Task<List<T>> GetAll();
    Task<T?> Update(T item);
    Task<bool> Delete(Guid id);
}