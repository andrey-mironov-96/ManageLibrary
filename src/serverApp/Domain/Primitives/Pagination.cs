namespace Domain.Primitives
{
    public class Pagination<T>(ushort page, ushort pageSize)
        where T : class
    {
        public ushort Page { get; set; } = page;
        public ushort PageSize { get; set; } = pageSize;
        public IEnumerable<T> Data { get; set; } = [];
        public int Total { get; set; }

    }
}
