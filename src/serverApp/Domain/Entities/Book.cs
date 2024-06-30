using Domain.Primitives;

namespace Domain.Entities
{
    public sealed class Book : Entity
    {
        public Book(Guid id, string name, int pages, string author) : base(id)
        {
            Name = name;
            Pages = pages;
            Author = author;
        }
        private Book() { }

        public string Name { get; private set; } = string.Empty;

        public string Author { get; private set; } = string.Empty;

        public int Pages { get; private set; }

        public BookPlace? BookPlace { get; private set; }

        public Guid? BookPlaceId { get; private set; }

        public override string ToString()
        {
            return string.Format("Id: {id}, Name: {Name},  Author:{Author},  Pages:{Pages},  BookPlaceId:{BookPlaceId}", Id, Name, Author, Pages);
        }
    }
}
