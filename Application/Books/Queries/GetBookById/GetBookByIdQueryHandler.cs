using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Books.Queries.GetBookById;

internal sealed class GetBookByIdQueryHandler : IQueryHandler<GetBookByIdQuery, BookResponse>
{
    private readonly IBookRepository bookRepository;

    public GetBookByIdQueryHandler(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }
    public async Task<BookResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        Book book = await bookRepository.GetByIdAsync(request.bookId, cancellationToken);
        if(book is null)
        {
            throw new BookNotFoundException(request.bookId);
        }
        return new BookResponse(book.Id, book.Name, book.Pages, book.Author);
    }
}
