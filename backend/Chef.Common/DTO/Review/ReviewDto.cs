using System;
using Chef.Common.DTO.Base;
using Chef.Common.DTO.Recipe;
using Chef.Common.DTO.User;

namespace Chef.Common.DTO.Review
{
    public class ReviewDto : AuditDto
    {
        public string Description { get; set; }
        public bool IsAlreadyCooked { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
