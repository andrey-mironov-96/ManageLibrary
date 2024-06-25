using System.ComponentModel.DataAnnotations.Schema;
using Domain.Exceptions;
using Domain.Primitives;

namespace Domain.Entities
{
    [NotMapped]
    public class BookPlace(Guid id, Guid shelfId) : Entity(id)
    {
        public Guid ShelfId { get; private set; } = shelfId;

        public Shelf? Shelf { get; private set; }

        public List<Book> Books { get; private set; } = [];

        public BookPlace AddBookToBookplace(Book book)
        {
            if (Books.Any(b => b.Id == book.Id))
            {
                throw new BookAlreadyExistsOnShelf(book);
            }

            Books.Add(book);
            return this;
        }
    }
}