namespace Application.Features.Shelves.Commands.UpdateShelf;

public record UpdateShelfRequest(Guid Id, ushort Number, ushort CountBook, string Name, Guid BookcaseId);
