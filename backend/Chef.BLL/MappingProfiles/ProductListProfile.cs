using AutoMapper;
using Chef.Common.DTO.ProductList;
using Chef.DAL.Entities;

namespace Chef.BLL.MappingProfiles
{
    public class ProductListProfile : Profile
    {
        public ProductListProfile()
        {
            CreateMap<ProductList, ProductListDto>();

            CreateMap<ProductListDto, ProductList>();
        }
    }
}
