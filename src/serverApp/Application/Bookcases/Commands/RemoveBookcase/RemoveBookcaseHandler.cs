using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Abstractions;

namespace Application.Bookcases.Commands.RemoveBookcase
{
    public class RemoveBookcaseHandler(IBookcaseRepository bookcaseRepository, IUnitOfWork unitOfWork) : ICommandHandler<RemoveBookcaseCommand, bool>
    {
        private readonly IBookcaseRepository _bookcaseRepository = bookcaseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<bool> Handle(RemoveBookcaseCommand request, CancellationToken cancellationToken)
        {
            await _bookcaseRepository.RemoveAsync(request.BookcaseId, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
