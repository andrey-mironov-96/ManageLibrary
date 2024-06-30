using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public sealed class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Book> GetByIdAsync(Guid bookId, CancellationToken cancellationToken)
        {
            return _dbContext.Set<Book>().SingleAsync(x => x.Id == bookId, cancellationToken);
        }

        public void Insert(Book book)
        {
            _dbContext.Set<Book>().Add(book);
        }
    }
}
