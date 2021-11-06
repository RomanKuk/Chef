using Chef.Common.DTO.Base;
using Chef.Common.DTO.IngredientCategory;

namespace Chef.Common.DTO.Ingredient
{
    public class IngredientDto : BaseDto
    {
        public string Name { get; set; }
        public int IngredientCategoryId { get; set; }
        public IngredientCategoryDto Category { get; set; }
    }
}
