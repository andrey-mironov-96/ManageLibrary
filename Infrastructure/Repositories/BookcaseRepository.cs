using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Domain.Abstractions;
using Domain.Entities;
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
        public async Task<IEnumerable<Bookcase>> GetBookcases(CancellationToken cancellationToken)
        {
            IEnumerable<Bookcase> bookcases = await _dbContext.Set<Bookcase>().ToListAsync(cancellationToken);
            return bookcases;
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
    }
}