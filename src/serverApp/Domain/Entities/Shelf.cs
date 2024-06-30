using System.ComponentModel.DataAnnotations.Schema;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Shelf : Entity
    {

#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.
        public Shelf() { }
        public Shelf(Guid id, ushort number, ushort countBook, string name, Guid bookcaseId) : base(id)
        {
            this.Number = number;
            this.CountBooks = countBook;
            this.Name = name;
            this.BookcaseId = bookcaseId;
        }

#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Возможно, стоит объявить поле как допускающее значения NULL.

        public ushort Number { get; private set; }
        public ushort CountBooks { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Guid BookcaseId { get; set; }

        public Bookcase Bookcase { get; set; }
    }
}