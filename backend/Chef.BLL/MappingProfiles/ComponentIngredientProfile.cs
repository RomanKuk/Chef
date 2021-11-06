using AutoMapper;
using Chef.Common.DTO.ComponentIngredient;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class ComponentIngredientProfile : Profile
    {
        public ComponentIngredientProfile()
        {
            CreateMap<ComponentIngredient, ComponentIngredientDto>();

            CreateMap<ComponentIngredientDto, ComponentIngredient>();
        }
    }
}
