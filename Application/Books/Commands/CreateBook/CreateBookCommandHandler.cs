using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;

namespace Application.Books.Commands.CreateBook;

internal sealed class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, Guid>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IBookRepository bookRepository;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        this.unitOfWork = unitOfWork;
        this.bookRepository = bookRepository;
    }

    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        Book book = new Book(Guid.NewGuid(), request.Name, request.Pages, request.Author);
        bookRepository.Insert(book);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return book.Id;
    }
}
