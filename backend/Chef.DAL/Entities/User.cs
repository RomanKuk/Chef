using System.Collections.Generic;
using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class User : AuditEntity
    {
        public User()
        {
            SavedRecipes = new List<Recipe>();
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UId { get; set; }
        public string AvatarUrl { get; set; }
        public int ProductListId { get; set; }
        public ProductList ProductList { get; set; }
        public ICollection<Recipe> SavedRecipes { get; set; }
    }
}
