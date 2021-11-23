using System.Collections.Generic;
using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class ProductList : Entity
    {
        public ProductList()
        {
            Ingredients = new List<ProductListIngredient>();
        }

        public ICollection<ProductListIngredient> Ingredients { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
