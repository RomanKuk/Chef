using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class RecipeIngredient : Entity
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public double Quantity { get; set; }
        public string Description { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
