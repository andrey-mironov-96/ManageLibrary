using Application.DTO;
using Domain.Entities;
using Mapster;

namespace Application.Mappers
{
    public class BookcaseMapsterConfig
    {
        public BookcaseMapsterConfig()
        {
            TypeAdapterConfig<Bookcase, BookcaseDTO>.NewConfig()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Number, src => src.Number)
                .Map(dest => dest.MaxSizeShelves, src => src.MaxSizeShelves);

        }
    }
}
