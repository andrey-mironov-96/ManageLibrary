using Domain.Entities;

namespace Domain.Exceptions
{
    public class BookAlreadyExistsOnShelf(Book book) : Exception($"Already exists book: {book}")
    {
    }
}