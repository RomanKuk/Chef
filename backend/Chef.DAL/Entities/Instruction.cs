using Chef.DAL.Entities.Common;

namespace Chef.DAL.Entities
{
    public class Instruction : Entity
    {
        public int OrderNumber { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
