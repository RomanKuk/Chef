using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chef.BLL.Exceptions;
using Chef.BLL.Interfaces;
using Chef.BLL.Services.Abstract;
using Chef.Common.DTO.Recipe;
using Chef.Common.DTO.User;
using Chef.DAL.Context;
using Chef.DAL.Entities;
using Microsoft.AspNetCore.Http;
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
            var recipes = (await GetAllAsync()).ToList();

            recipes.ForEach(async r =>
            {
                var recipeComponents = await Context.RecipeComponents
                    .AsNoTracking()
                    .Include(c => c.Ingredients)
                    .ToListAsync();
                r.SummaryTime = r.CookingTime + r.PreparationTime;
                r.IngredientsCount = recipeComponents.Sum(c => c.Ingredients.Count);
            });

            return recipes;
        }

        public async Task<RecipeDto> GetUserById(int id)
        {
            return await GetAsync(id);
        }
    }
}
