using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Application.DTO;
using Domain.Abstractions;
using Domain.Entities;
using Mapster;

namespace Application.Features.Shelves.Commands.UpdateShelf
{
    public sealed class UpdateShelfCommandHandler : ICommandHandler<UpdateShelfCommand, ShelfDTO>
    {
        private readonly IShelfRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateShelfCommandHandler(IShelfRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ShelfDTO> Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
        {
            ShelfDTO shelfDTO = new()
            {
                BookcaseId = request.BookcaseId,
                CountBooks = request.CountBook,
                Id = request.Id,
                Name = request.Name,
                Number = request.Number
            };
            Shelf shelf = shelfDTO.Adapt<Shelf>();
            _repository.Update(shelf);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            shelfDTO = shelf.Adapt<ShelfDTO>();
            return shelfDTO;
        }
    }
}
