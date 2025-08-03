using Core.Entities;

namespace Core.Interfaces;

public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T?> GetWithSpec(ISpecification<T> spec);
    Task<TResult?> GetWithSpec<TResult>(ISpecification<T, TResult> spec);
    Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
    Task<IReadOnlyList<TResult>> GetAllWithSpec<TResult>(ISpecification<T, TResult> spec);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> SaveAsync();
    bool Exists(int id);
}