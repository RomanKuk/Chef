using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chef.BLL.Interfaces;
using Chef.BLL.Services.Abstract;
using Chef.Common.DTO.Recipe;
using Chef.DAL.Context;
using Chef.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chef.BLL.Services
{
    public class RecipeService : BaseCrudService<Recipe, RecipeDto, RecipeDto>, IRecipeService
    {

        public RecipeService(ChefContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<ICollection<RecipeDto>> GetAll()
        {
            var recipesEntity = await Context.Recipes
                .AsNoTracking()
                .Include(r => r.Components)
                .ThenInclude(c => c.Ingredients)
                .ToListAsync();

            var recipes = Mapper.Map<List<RecipeDto>>(recipesEntity);

            recipes.ForEach(r =>
            {
                r.SummaryTime = r.CookingTime + r.PreparationTime;
                r.IngredientsCount = r.Components.Sum(c => c.Ingredients.Count);
            });

            return recipes;
        }

        public async Task<RecipeDto> GetRecipeById(int id)
        {
            var recipe = await Context.Recipes
                .AsNoTracking()
                .Include(r => r.Components)
                    .ThenInclude(c => c.Ingredients)
                    .ThenInclude(c => c.Ingredient)
                .Include(c => c.Components)
                    .ThenInclude(c => c.Ingredients)
                    .ThenInclude(i => i.VolumeMetric)
                .Include(r => r.Instructions)
                .Include(r => r.Reviews)
                .FirstOrDefaultAsync(r => r.Id == id);

            return Mapper.Map<RecipeDto>(recipe);
        }
    }
}
