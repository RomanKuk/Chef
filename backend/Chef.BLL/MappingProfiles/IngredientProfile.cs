using AutoMapper;
using Chef.Common.DTO.Ingredient;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile()
        {
            CreateMap<Ingredient, IngredientDto>();

            CreateMap<IngredientDto, Ingredient>();
        }
    }
}
