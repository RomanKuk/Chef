using System.Collections.Generic;
using Chef.Common.DTO.Base;
using Chef.Common.DTO.ProductList;
using Chef.Common.DTO.Recipe;

namespace Chef.Common.DTO.User
{
    public class UserDto : AuditDto
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UId { get; set; }
        public string AvatarUrl { get; set; }
        public int ProductListId { get; set; }
        public ProductListDto ProductList { get; set; }
        public ICollection<RecipeDto> SavedRecipes { get; set; }
    }
}
