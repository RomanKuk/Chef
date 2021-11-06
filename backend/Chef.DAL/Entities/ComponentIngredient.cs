using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class ComponentIngredient : Entity
    {
        public int RecipeComponentId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public Ingredient Ingredient { get; set; }
        public RecipeComponent RecipeComponent { get; set; }
        public int? VolumeMetricId { get; set; }
        public VolumeMetric VolumeMetric { get; set; }
    }
}
