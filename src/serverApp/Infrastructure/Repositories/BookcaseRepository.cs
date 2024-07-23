using Application.Abstractions.Repositories;
using Application.DTO;
using Application.Primitives;
using Domain.Entities;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BookcaseRepository : IBookcaseRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BookcaseRepository(ApplicationDbContext applicationDb)
        {
            _dbContext = applicationDb;
        }
        public async Task<Pagination<BookcaseDTO>> GetBookcasesAsync(Pagination<BookcaseDTO> pagination, CancellationToken cancellationToken)
        {
            var result = await _dbContext.Set<Bookcase>().ToPaginateAsync<Bookcase, BookcaseDTO>(pagination, cancellationToken);
            
            return result;
        }

        public async Task<Bookcase> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            Bookcase bookcase = await _dbContext.Set<Bookcase>().FirstAsync(x => x.Id == id, cancellationToken);
            return bookcase;
        }

        public void Insert(Bookcase value)
        {
            _dbContext.Set<Bookcase>().Add(value);
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            Bookcase bookcase = await _dbContext.Set<Bookcase>().FirstAsync(x => x.Id == id, cancellationToken);
            _dbContext.Set<Bookcase>().Remove(bookcase);
        }

        public void Update(Bookcase value)
        {
            _dbContext.Update(value);
        }
    }
}