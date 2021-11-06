using System.Collections.Generic;
using Chef.Common.DTO.Base;
using Chef.Common.DTO.ComponentIngredient;
using Chef.Common.DTO.Recipe;

namespace Chef.Common.DTO.RecipeComponent
{
    public class RecipeComponentDto : BaseDto
    {
        public string Name { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
        public ICollection<ComponentIngredientDto> Ingredients { get; set; }
    }
}
