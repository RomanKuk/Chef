using System.Threading.Tasks;
using AutoMapper;
using Chef.BLL.Interfaces;
using Chef.BLL.Services.Abstract;
using Chef.Common.DTO.ProductList;
using Chef.Common.DTO.Recipe;
using Chef.DAL.Context;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chef.BLL.Services
{
    public class ProductListService : BaseCrudService<ProductList, ProductListDto, ProductListDto>, IProductListService
    {

        public ProductListService(ChefContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ProductListDto> GetProductListByUserId(int id)
        {
            var productListEntity = await Context.ProductLists
                .AsNoTracking()
                .Include(pl => pl.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .ThenInclude(i => i.Category)
                .Include(pl => pl.Ingredients)
                .ThenInclude(i => i.VolumeMetric)
                .FirstOrDefaultAsync(pl => pl.UserId == id);

            return Mapper.Map<ProductListDto>(productListEntity);
        }
    }
}
