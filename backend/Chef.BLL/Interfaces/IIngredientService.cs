using System.Collections.Generic;
using System.Threading.Tasks;
using Chef.Common.DTO.Ingredient;

namespace Chef.BLL.Interfaces
{
    public interface IIngredientService
    {
        Task<List<IngredientDto>> GetAll();
    }
}
