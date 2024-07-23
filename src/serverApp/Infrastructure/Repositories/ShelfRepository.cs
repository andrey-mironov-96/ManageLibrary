using Application.Abstractions.Repositories;
using Application.DTO;
using Application.Primitives;
using Domain.Entities;
using Infrastructure.Extensions;
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

        public async Task<Pagination<ShelfDTO>> GetShelvesByBookcaseIdAsync(Guid bookcaseId, Pagination<ShelfDTO> pagination, CancellationToken cancellationToken)
        {
            return await _dbContext.Set<Shelf>().Where(_ => _.BookcaseId == bookcaseId).ToPaginateAsync(pagination, cancellationToken);
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

        public void Update(Shelf value)
        {
            _dbContext.Update(value);
        }
    }
}