using Domain.Exceptions;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Bookcase(Guid id, ushort number, string name, uint maxSizeShelves) : Entity(id)
    {
        public ushort Number { get; private set; } = number;

        public string Name { get; private set; } = name;

        public uint MaxSizeShelves { get; private set; } = maxSizeShelves;

        public List<Shelf> Shelves { get; private set; } = [];

        public void AddShelve(ushort countBook, string shelfName)
        {
            if (this.Shelves.Count == this.MaxSizeShelves)
            {
                throw new NoShelfPlaceException(this.Id);
            }

            this.Shelves.Add(
                new(
                    Guid.NewGuid(),
                    (ushort)this.Shelves.Count,
                    countBook,
                    shelfName, 
                    this.Id
                )
            );
        }
    }




}