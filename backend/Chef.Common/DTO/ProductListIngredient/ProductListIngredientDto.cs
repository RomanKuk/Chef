using Chef.Common.DTO.Base;
using Chef.Common.DTO.Ingredient;
using Chef.Common.DTO.ProductList;
using Chef.Common.DTO.VolumeMetric;

namespace Chef.Common.DTO.ProductListIngredient
{
    public class ProductListIngredientDto : BaseDto
    {
        public int ProductListId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }
        public IngredientDto Ingredient { get; set; }
        public ProductListDto ProductList { get; set; }
        public int VolumeMetricId { get; set; }
        public VolumeMetricDto VolumeMetric { get; set; }
    }
}
