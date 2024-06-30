namespace Domain.Abstractions;
public interface IBaseRepository<T>
where T : class
{
    Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Insert(T value);

    Task RemoveAsync(Guid id, CancellationToken cancellationToken);
}
