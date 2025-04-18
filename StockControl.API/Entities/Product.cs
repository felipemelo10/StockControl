namespace StockControl.API.Entities
{
    public class Product
    {
        public int Id { get; init; }
        public string? Sku { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<StockMovement> StockMovements { get; set; }

        public Product()
        {
            StockMovements = new HashSet<StockMovement>();
        }
    }
}
