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
    }
}
