using Chef.Common.DTO.Base;
using Chef.Common.DTO.IngredientCategory;
using Chef.Common.DTO.VolumeMetric;

namespace Chef.Common.DTO.Ingredient
{
    public class IngredientDto : BaseDto
    {
        public string Name { get; set; }
        public int IngredientCategoryId { get; set; }
        public IngredientCategoryDto Category { get; set; }
        public int VolumeMetricId { get; set; }
        public VolumeMetricDto VolumeMetric { get; set; }
    }
}
