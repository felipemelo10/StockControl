namespace StockControl.API.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public EMovementType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime MovementDate { get; set; }
        public string? Reason { get; set; } //Motivo ou Justificativa
        public string? BatchNumber { get; set; } //Numero do lote da entrega
    }
}