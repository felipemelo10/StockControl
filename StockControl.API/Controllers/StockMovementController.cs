using Microsoft.AspNetCore.Mvc;
using StockControl.API.DTOs;
using StockControl.API.Services;

namespace StockControl.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockMovementController : ControllerBase
    {
        private readonly IStockMovementService _stockMovementService;

        public StockMovementController(IStockMovementService stockMovementService)
        {
            _stockMovementService = stockMovementService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var stockMovement = await _stockMovementService.GetByIdAsync(id);

            if(stockMovement == null)
            {
                return NotFound();
            }

            return Ok(stockMovement);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(StockMovementDTO stockMovementDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stockMovement = await _stockMovementService.CreateAsync(stockMovementDTO);

            return Ok(stockMovement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(int id)
        {
            var stockMovementDTO = await _stockMovementService.DeleteByIdAsync(id);

            if(stockMovementDTO == false)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
