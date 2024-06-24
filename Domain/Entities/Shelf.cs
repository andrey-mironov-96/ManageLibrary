using System.ComponentModel.DataAnnotations.Schema;
using Domain.Primitives;

namespace Domain.Entities
{
     [NotMapped]
    public class Shelf(Guid id, ushort number, ushort countBook, string name, Guid bookcaseId) : Entity(id)
    {
        public ushort Number { get; private set; } = number;
        public ushort CountBook { get; private set; } = countBook;
        public string Name { get; private set; } = name;
        public Guid BookcaseId { get; set; } = bookcaseId;
    }
}