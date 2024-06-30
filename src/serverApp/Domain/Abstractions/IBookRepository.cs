using Domain.Entities;

namespace Domain.Abstractions
{
    public interface IBookRepository
    {
        Task<Book> GetByIdAsync(Guid bookId, CancellationToken cancellationToken);
        void Insert(Book book);
    }
}
