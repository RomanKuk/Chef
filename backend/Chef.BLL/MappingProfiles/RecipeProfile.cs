using AutoMapper;
using Chef.Common.DTO.Recipe;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class RecipeProfile : Profile
    {
        public RecipeProfile()
        {
            CreateMap<Recipe, RecipeDto>();

            CreateMap<RecipeDto, Recipe>();
        }
    }
}
