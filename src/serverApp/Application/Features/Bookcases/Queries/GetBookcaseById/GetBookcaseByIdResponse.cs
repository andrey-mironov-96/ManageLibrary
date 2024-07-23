namespace Application.Features.Bookcases.Queries.GetBookcaseById;

public sealed record GetBookcaseByIdResponse(Guid Id, ushort Number, string Name, uint MaxSizeShelves);
