using Microsoft.AspNetCore.Mvc;
using StockControl.API.DTOs;
using StockControl.API.Services;

namespace StockControl.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAll();
            return Ok(products);
        }
        
        [HttpGet("{id}")]
        [ActionName(nameof(GetByIdAsync))]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsyncProduct(AddProductDTO addProductDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(addProductDTO == null)
            {
                return BadRequest();
            }

            var createdProductDTO = await _productService.CreateAsync(addProductDTO);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = createdProductDTO.Id}, createdProductDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var productDTO = await _productService.DeleteByIdAsync(id);

            if(productDTO == false)
            {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}
