using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Chef.BLL.Interfaces;
using Chef.BLL.Services.Abstract;
using Chef.Common.DTO.Recipe;
using Chef.Common.Enums;
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

        public async Task<ICollection<RecipeDto>> GetFilteredRecipes(FilterRecipeDto filter)
        {
            var recipes = await GetAll();

            if (filter.CookingTimeOptions.Any())
            {
                recipes = GetRecipesByCookingTime(recipes, filter.CookingTimeOptions);
            }

            if (filter.IngredientsCountOptions.Any())
            {
                recipes = GetRecipesByIngredientsCount(recipes, filter.IngredientsCountOptions);
            }

            if (filter.ProductsIds.Any())
            {
                recipes = recipes.Where(r =>
                    r.Components.Any(c => c.Ingredients.Any(i => filter.ProductsIds.Contains(i.IngredientId)))).ToList();
            }

            recipes = !string.IsNullOrEmpty(filter.SortingBy) ? GetSortedRecipesListByOption(recipes, filter.SortingBy) : 
                recipes.OrderBy(r => r.Id).ToList();

            return recipes;
        }

        private static ICollection<RecipeDto> GetSortedRecipesListByOption(ICollection<RecipeDto> recipes, string filterSortingBy)
        {
            return filterSortingBy switch
            {
                nameof(SortingOptions.Latest) => recipes.OrderByDescending(r => r.CreatedAt).ToList(),
                nameof(SortingOptions.Popular) => recipes.OrderByDescending(r => r.LikeCount).ToList(),
                nameof(SortingOptions.Featured) => recipes.OrderBy(r => r.Id).ToList(),
                _ => throw new ArgumentOutOfRangeException(nameof(filterSortingBy), filterSortingBy, null)
            };
        }

        private static ICollection<RecipeDto> GetRecipesByIngredientsCount(ICollection<RecipeDto> recipes, ICollection<string> filterIngredientsCountOptions)
        {
            var filteredRecipes = new List<RecipeDto>();

            foreach (var filterCookingTimeOption in filterIngredientsCountOptions)
            {
                switch (filterCookingTimeOption)
                {
                    case nameof(IngredientsCountOptions.less5):
                    {
                        filteredRecipes
                            .AddRange(recipes.Where(r => r.IngredientsCount < 5).Distinct());
                        break;
                    }
                    case nameof(IngredientsCountOptions.from5To9):
                    {
                        filteredRecipes
                            .AddRange(recipes.Where(r => r.IngredientsCount is >= 5 and < 9).Distinct());
                        break;
                    }
                    case nameof(IngredientsCountOptions.from9To15):
                    {
                        filteredRecipes.AddRange(recipes.Where(r => r.IngredientsCount is >= 9 and < 15).Distinct());
                        break;
                    }
                    case nameof(IngredientsCountOptions.more15):
                    {
                        filteredRecipes
                            .AddRange(recipes.Where(r => r.IngredientsCount >= 15).Distinct());
                        break;
                    }
                }
            }

            return filteredRecipes;
        }

        private static ICollection<RecipeDto> GetRecipesByCookingTime(ICollection<RecipeDto> recipes, ICollection<string> filterCookingTimeOptions)
        {
            var filteredRecipes = new List<RecipeDto>();

            foreach (var filterCookingTimeOption in filterCookingTimeOptions)
            {
                switch (filterCookingTimeOption)
                {
                    case nameof(CookingTimeOptions.less15min):
                    {
                        filteredRecipes
                            .AddRange(recipes.Where(r => r.SummaryTime < TimeSpan.FromMinutes(15)).Distinct());
                        break;
                    }
                    case nameof(CookingTimeOptions.from15minTo1hr):
                    {
                        filteredRecipes
                            .AddRange(recipes.Where(r => r.SummaryTime >= TimeSpan.FromMinutes(15) && 
                                                         r.SummaryTime < TimeSpan.FromHours(1)).Distinct());
                        break;
                    }
                    case nameof(CookingTimeOptions.from1hrTo2hrs):
                    {
                        filteredRecipes
                            .AddRange(recipes.Where(r => r.SummaryTime > TimeSpan.FromHours(1) &&
                                                         r.SummaryTime < TimeSpan.FromHours(2)).Distinct());
                        break;
                    }
                    case nameof(CookingTimeOptions.more2hrs):
                    {
                        filteredRecipes
                            .AddRange(recipes.Where(r => r.SummaryTime > TimeSpan.FromHours(2)).Distinct());
                        break;
                    }
                }
            }

            return filteredRecipes;
        }
    }
}
