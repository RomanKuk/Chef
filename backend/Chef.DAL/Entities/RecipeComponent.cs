using System.Collections;
using System.Collections.Generic;
using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class RecipeComponent : Entity
    {
        public RecipeComponent()
        {
            Ingredients = new List<ComponentIngredient>();
        }

        public string Name { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public ICollection<ComponentIngredient> Ingredients { get; set; }
    }
}
