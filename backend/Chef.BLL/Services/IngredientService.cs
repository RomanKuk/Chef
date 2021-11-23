using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Chef.BLL.Interfaces;
using Chef.BLL.Services.Abstract;
using Chef.Common.DTO.Ingredient;
using Chef.Common.DTO.ProductList;
using Chef.Common.DTO.Recipe;
using Chef.DAL.Context;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chef.BLL.Services
{
    public class IngredientService : BaseCrudService<Ingredient, IngredientDto, IngredientDto>, IIngredientService
    {

        public IngredientService(ChefContext context, IMapper mapper) : base(context, mapper)
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

        public async Task<List<IngredientDto>> GetAll()
        {
            var ingredientsEntity = await Context.Ingredients
                .AsNoTracking()
                .Include(i => i.Category)
                .ToListAsync();

            return Mapper.Map<List<IngredientDto>>(ingredientsEntity);
        }
    }
}
