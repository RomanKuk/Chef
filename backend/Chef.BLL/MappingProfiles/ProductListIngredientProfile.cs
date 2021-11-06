using AutoMapper;
using Chef.Common.DTO.ProductListIngredient;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class ProductListIngredientProfile : Profile
    {
        public ProductListIngredientProfile()
        {
            CreateMap<ProductListIngredient, ProductListIngredientDto>();

            CreateMap<ProductListIngredientDto, ProductListIngredient>();
        }
    }
}
