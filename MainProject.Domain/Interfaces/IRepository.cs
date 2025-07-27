using MainProject.Domain.Common;

namespace MainProject.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
    }
}