using Domain.Abstractions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ShelfRepository(ApplicationDbContext dbContext) : IShelfRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;
        public async Task<Shelf> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Shelf>().FirstAsync(_ => _.Id == id, cancellationToken);
        }

        public void Insert(Shelf value)
        {
            _dbContext.Set<Shelf>().Add(value);
        }

        public async Task RemoveAsync(Guid id, CancellationToken cancellationToken)
        {
            Shelf shelf = await _dbContext.Set<Shelf>().FirstAsync(x => x.Id == id, cancellationToken);
            _dbContext.Set<Shelf>().Remove(shelf);
        }
    }
}