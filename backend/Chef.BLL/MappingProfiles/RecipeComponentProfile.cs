using AutoMapper;
using Chef.Common.DTO.RecipeComponent;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class RecipeComponentProfile : Profile
    {
        public RecipeComponentProfile()
        {
            CreateMap<RecipeComponent, RecipeComponentDto>();

            CreateMap<RecipeComponentDto, RecipeComponent>();
        }
    }
}
