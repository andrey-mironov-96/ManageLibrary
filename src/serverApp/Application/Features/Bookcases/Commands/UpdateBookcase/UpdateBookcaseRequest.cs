namespace Application.Features.Bookcases.Commands.UpdateBookcase
{
    public sealed record UpdateBookcaseRequest(Guid Id, ushort Number, string Name, uint MaxSizeShelves);
}
