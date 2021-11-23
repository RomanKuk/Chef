using System.Collections.Generic;
using System.Threading.Tasks;
using Chef.BLL.Interfaces;
using Chef.Common.DTO.Recipe;
using Microsoft.AspNetCore.Mvc;

namespace Chef.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeService _recipeService;

        public RecipesController(IRecipeService userService)
        {
            _recipeService = userService;
        }

        [HttpGet]
        public async Task<ICollection<RecipeDto>> Get()
        {
            return await _recipeService.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<RecipeDto> Get(int id)
        {
            return await _recipeService.GetRecipeById(id);
        }

        [HttpPost("get-filtered-recipes")]
        public async Task<ICollection<RecipeDto>> GetFilteredRecipes([FromBody] FilterRecipeDto filter)
        {
            return await _recipeService.GetFilteredRecipes(filter);
        }
    }
}
