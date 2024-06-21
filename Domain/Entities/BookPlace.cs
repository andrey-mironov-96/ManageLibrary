using Domain.Primitives;

namespace Domain.Entities
{
    public class BookPlace(Guid id, Book book, Bookcase bookcase, Shelf shelf) : Entity(id)
    {
        public Book Book { get; private set; } = book;
        public Bookcase Bookcase { get; private set; } = bookcase;
        public Shelf Shelf { get; private set; } = shelf;
    }
}