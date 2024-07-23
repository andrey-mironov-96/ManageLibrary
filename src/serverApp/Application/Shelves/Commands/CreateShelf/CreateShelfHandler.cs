using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Shelves.Commands.CreateShelf
{
    public sealed class CreateShelfHandler(IShelfRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<CreateShelfCommand, Guid>
    {
        private readonly IShelfRepository _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(CreateShelfCommand request, CancellationToken cancellationToken)
        {
            Shelf shelf = new Shelf(
                Guid.NewGuid(),
                request.Number,
                request.CountBook,
                request.Name,
                request.BookcaseId
            );

            _repository.Insert(shelf);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return shelf.Id;
        }
    }
}