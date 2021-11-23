using System.Collections.Generic;

namespace Chef.Common.DTO.Recipe
{
    public class FilterRecipeDto
    {
        public ICollection<string> CookingTimeOptions { get; set; }
        public ICollection<string> IngredientsCountOptions { get; set; }
        public ICollection<int> ProductsIds { get; set; }
        public string SortingBy { get; set; }
    }
}
