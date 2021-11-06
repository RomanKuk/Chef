using System;
using System.Collections.Generic;
using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class Recipe : AuditEntity
    {
        public Recipe()
        {
            Components = new List<RecipeComponent>();
            Instructions = new List<Instruction>();
            Reviews = new List<Review>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? CookingTime { get; set; }
        public TimeSpan? PreparationTime { get; set; }
        public int DefaultServingsCount { get; set; }
        public int CategoryId { get; set; }
        public RecipeCategory Category { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public ICollection<RecipeComponent> Components { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
