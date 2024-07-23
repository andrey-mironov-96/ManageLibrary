using Application.Abstractions.Messaging;
using Application.Abstractions.Repositories;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Features.Bookcases.Commands.CreateBookcase
{
    public sealed class CreateBookcaseHandler : ICommandHandler<CreateBookcaseCommand, Guid>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBookcaseRepository _bookcaseRepository;

        public CreateBookcaseHandler(IUnitOfWork unitOfWork, IBookcaseRepository bookcaseRepository)
        {
            _unitOfWork = unitOfWork;
            _bookcaseRepository = bookcaseRepository;
        }
        public async Task<Guid> Handle(CreateBookcaseCommand request, CancellationToken cancellationToken)
        {
            Bookcase bookcase = new(Guid.NewGuid(), request.Number, request.Name, request.MaxSizeShelve);
            _bookcaseRepository.Insert(bookcase);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return bookcase.Id;
        }
    }
}