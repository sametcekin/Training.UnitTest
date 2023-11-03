using Microsoft.AspNetCore.Mvc;
using Training.UnitTest.Business;
using Training.UnitTest.Contracts;

namespace Training.UnitTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductCreateDTO product)
        {
            var result = await _service.CreateAsync(product);
            return Ok(result);
        }
    }
}
