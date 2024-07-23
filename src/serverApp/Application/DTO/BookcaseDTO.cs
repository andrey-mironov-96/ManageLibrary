namespace Application.DTO
{
    public class BookcaseDTO
    {
        public Guid Id { get; set; }
        public ushort Number { get; set; }

        public required string Name { get; set; }

        public uint MaxSizeShelves { get; set; }
    }
}
