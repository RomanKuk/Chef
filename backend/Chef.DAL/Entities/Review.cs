using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class Review : AuditEntity
    {
        public string Description { get; set; }
        public bool IsAlreadyCooked { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
