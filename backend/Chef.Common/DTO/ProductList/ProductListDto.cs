using System.Collections.Generic;
using Chef.Common.DTO.Base;
using Chef.Common.DTO.ProductListIngredient;

namespace Chef.Common.DTO.ProductList
{
    public class ProductListDto : BaseDto
    {
        public ICollection<ProductListIngredientDto> Ingredients { get; set; }
    }
}
