using System.Threading.Tasks;
using Chef.Common.DTO.ProductList;

namespace Chef.BLL.Interfaces
{
    public interface IProductListService
    {
        Task<ProductListDto> GetProductListByUserId(int id);
    }
}
