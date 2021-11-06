using System;
using Chef.Common.DTO.Base;
using Chef.Common.DTO.Recipe;
using Chef.Common.DTO.User;

namespace Chef.Common.DTO.Review
{
    public class NewReviewDto : AuditDto
    {
        public string Description { get; set; }
        public bool IsAlreadyCooked { get; set; }
        public int RecipeId { get; set; }
        public int UserId { get; set; }
    }
}
