using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Features.Bookcases.Commands.UpdateBookcase
{
    public sealed class UpdateBookcaseHandler(IBookcaseRepository bookcaseRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateBookcaseCommand, Guid>
    {
        private readonly IBookcaseRepository _bookcaseRepository = bookcaseRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> Handle(UpdateBookcaseCommand request, CancellationToken cancellationToken)
        {

            Bookcase bookcase = new(request.Id, request.Number, request.Name, request.MaxSizeShelves);
            _bookcaseRepository.Update(bookcase);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return bookcase.Id;
        }
    }
}
