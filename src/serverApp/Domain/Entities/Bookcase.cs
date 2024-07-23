using Domain.Exceptions;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Bookcase(Guid id, ushort number, string name, uint maxSizeShelves) : Entity(id)
    {
        public ushort Number { get; set; } = number;

        public string Name { get; set; } = name;

        public uint MaxSizeShelves { get; set; } = maxSizeShelves;

        public List<Shelf> Shelves { get; set; } = [];

    }
}