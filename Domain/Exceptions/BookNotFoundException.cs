using Domain.Exceptions.Base;

namespace Domain.Exceptions
{
    public sealed class BookNotFoundException : NotFoundException
    {
        public BookNotFoundException(Guid bookId)
            : base($"The book with the inditefer {bookId} was not found")
        {
        }
    }
}
