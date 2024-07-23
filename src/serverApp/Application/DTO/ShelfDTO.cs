namespace Application.DTO
{
    public sealed class ShelfDTO
    {
        public Guid Id { get; set; }
        public ushort Number { get; set; }
        public ushort CountBooks { get; set; }
        public string Name { get; set; } = string.Empty;
        public Guid BookcaseId { get; set; }
    }
}
