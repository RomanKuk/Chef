using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class ProductListIngredient : Entity
    {
        public int ProductListId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public Ingredient Ingredient { get; set; }
        public ProductList ProductList { get; set; }
        public int? VolumeMetricId { get; set; }
        public VolumeMetric VolumeMetric { get; set; }
    }
}
