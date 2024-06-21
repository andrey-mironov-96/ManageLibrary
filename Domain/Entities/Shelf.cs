using Domain.Primitives;

namespace Domain.Entities
{
    public class Shelf(Guid id, ushort number, ushort countBook, string name, Bookcase bookcase) : Entity(id)
    {
        public ushort Number { get; private set; } = number;
        public ushort CountBook { get; private set; } = countBook;
        public string Name { get; private set; } = name;
        public Guid BookcaseId { get; set; } = bookcase.Id;
        public Bookcase Bookcase { get; set; } = bookcase;
    }
}