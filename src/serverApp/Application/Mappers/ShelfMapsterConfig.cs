using Application.DTO;
using Domain.Entities;
using Mapster;

namespace Application.Mappers;

public sealed class ShelfMapsterConfig
{
    public ShelfMapsterConfig()
    {
        TypeAdapterConfig<Shelf, ShelfDTO>.NewConfig()
            .Map(dest => dest.BookcaseId, src => src.BookcaseId)
            .Map(dest => dest.CountBooks, src => src.CountBooks)
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name)
            .Map(dest => dest.Number, src => src.Number);
    }
}
