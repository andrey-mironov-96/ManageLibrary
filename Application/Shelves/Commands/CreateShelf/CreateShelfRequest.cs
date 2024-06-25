namespace Application.Shelves.Commands.CreateShelf
{
    public sealed record CreateShelfRequest(ushort Number, ushort CountBook, string Name, Guid BookcaseId) { }

}