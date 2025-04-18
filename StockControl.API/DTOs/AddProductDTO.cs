using System.ComponentModel.DataAnnotations;

namespace StockControl.API.DTOs
{
    public class AddProductDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "The SKU is required.")]
        [MaxLength(50)]
        public string? Sku { get; set; }

        [Required(ErrorMessage = "The Name is required.")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "The Description is required.")]
        [MaxLength(250)]
        public string? Description { get; set; }
    }
}
