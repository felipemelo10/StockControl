using StockControl.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace StockControl.API.DTOs
{
    public class StockMovementDTO
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Product ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Product ID must be a valid positive number.")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Movement Type is required.")]
        [EnumDataType(typeof(EMovementType), ErrorMessage = "Invalid value for Movement Type.")]
        public EMovementType Type { get; set; }
        [Range(double.MinValue, double.MaxValue, ErrorMessage = "Invalid quantity value.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Movement Date is required.")]
        public DateTime MovementDate { get; set; }
        [MaxLength(255, ErrorMessage = "Reason cannot exceed 255 characters.")]
        public string? Reason { get; set; }
        public string? BatchNumber { get; set; }
    }
}