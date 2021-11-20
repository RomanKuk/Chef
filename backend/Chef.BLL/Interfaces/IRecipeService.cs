using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chef.Common.DTO.Recipe;
using Chef.Common.DTO.User;
using Microsoft.AspNetCore.Http;

namespace Chef.BLL.Interfaces
{
    public interface IRecipeService
    {
        Task<ICollection<RecipeDto>> GetAll();
        Task<RecipeDto> GetRecipeById(int id);
    }
}
