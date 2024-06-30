namespace Application.Bookcases.Commands.CreateBookcase
{
    public sealed record CreateBookcaseRequest(ushort Number, string Name, uint MaxSizeShelve);
}