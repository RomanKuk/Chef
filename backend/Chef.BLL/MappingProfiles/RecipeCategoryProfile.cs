using AutoMapper;
using Chef.Common.DTO.RecipeCategory;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class RecipeCategoryProfile : Profile
    {
        public RecipeCategoryProfile()
        {
            CreateMap<RecipeCategory, RecipeCategoryDto>();

            CreateMap<RecipeCategoryDto, RecipeCategory>();
        }
    }
}
