using System;
using System.Collections.Generic;
using Chef.Common.DTO.Base;
using Chef.Common.DTO.Instruction;
using Chef.Common.DTO.RecipeCategory;
using Chef.Common.DTO.RecipeComponent;
using Chef.Common.DTO.Review;

namespace Chef.Common.DTO.Recipe
{
    public class RecipeDto : AuditDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan? CookingTime { get; set; }
        public TimeSpan? PreparationTime { get; set; }
        public TimeSpan? SummaryTime { get; set; }
        public int DefaultServingsCount { get; set; }
        public int IngredientsCount { get; set; }
        public int CategoryId { get; set; }
        public string RecipeUrl { get; set; }
        public RecipeCategoryDto Category { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public ICollection<RecipeComponentDto> Components { get; set; }
        public ICollection<InstructionDto> Instructions { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
    }
}
