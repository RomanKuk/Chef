using System.Collections.Generic;
using System.Threading.Tasks;
using Chef.BLL.Interfaces;
using Chef.Common.DTO.Ingredient;
using Microsoft.AspNetCore.Mvc;

namespace Chef.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientService _ingredientService;

        public IngredientsController(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<List<IngredientDto>> Get()
        {
            return await _ingredientService.GetAll();
        }
    }
}
