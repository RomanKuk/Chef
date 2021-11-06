﻿using Chef.Common.DTO.Base;
using Chef.Common.DTO.Ingredient;
using Chef.Common.DTO.RecipeComponent;

namespace Chef.Common.DTO.ComponentIngredient
{
    public class ComponentIngredientDto: BaseDto
    {
        public int RecipeComponentId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public IngredientDto Ingredient { get; set; }
        public RecipeComponentDto RecipeComponent { get; set; }
    }
}
