using System;
using System.Collections.Generic;
using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class Recipe : Entity
    {
        public Recipe()
        {
            Ingredients = new List<RecipeIngredient>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan CookingTime { get; set; }
        public TimeSpan PreparationTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<RecipeIngredient> Ingredients { get; set; }
    }
}
