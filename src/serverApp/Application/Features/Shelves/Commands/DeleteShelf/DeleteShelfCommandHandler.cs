using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Abstractions;

namespace Application.Features.Shelves.Commands.DeleteShelf
{
    public sealed class DeleteShelfCommandHandler : ICommandHandler<DeleteShelfCommand, bool>
    {
        private readonly IShelfRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteShelfCommandHandler(IShelfRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
