using AutoMapper;
using Chef.Common.DTO.IngredientCategory;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class IngredientCategoryProfile : Profile
    {
        public IngredientCategoryProfile()
        {
            CreateMap<IngredientCategory, IngredientCategoryDto>();

            CreateMap<IngredientCategoryDto, IngredientCategory>();
        }
    }
}
