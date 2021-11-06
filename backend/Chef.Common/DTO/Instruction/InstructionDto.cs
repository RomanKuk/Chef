using Chef.Common.DTO.Base;
using Chef.Common.DTO.Recipe;

namespace Chef.Common.DTO.Instruction
{
    public class InstructionDto : BaseDto
    {
        public int OrderNumber { get; set; }
        public string Description { get; set; }
        public int RecipeId { get; set; }
        public RecipeDto Recipe { get; set; }
    }
}
