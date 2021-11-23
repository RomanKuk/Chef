using System.Collections.Generic;
using System.Threading.Tasks;
using Chef.BLL.Interfaces;
using Chef.Common.DTO.ProductList;
using Microsoft.AspNetCore.Mvc;

namespace Chef.API.Controllers
{
    //[Authorize]
    [Route("[controller]")]
    [ApiController]
    public class ProductListsController : ControllerBase
    {
        private readonly IProductListService _productListService;

        public ProductListsController(IProductListService productListService)
        {
            _productListService = productListService;
        }

        [HttpGet("{userId:int}")]
        public async Task<ProductListDto> Get(int userId)
        {
            return await _productListService.GetProductListByUserId(userId);
        }
    }
}
