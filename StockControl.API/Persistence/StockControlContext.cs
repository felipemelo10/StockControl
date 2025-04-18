using Microsoft.EntityFrameworkCore;
using StockControl.API.Entities;

namespace StockControl.API.Persistence
{
    public class StockControlContext : DbContext
    {
        public StockControlContext(DbContextOptions<StockControlContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>(p=> {
                p.HasKey(p=> p.Id);

                p.Property(p => p.Sku)
                .IsRequired()
                .HasMaxLength(50);

                p.HasIndex(p => p.Sku).IsUnique();

                p.Property(p=> p.Name)
                .IsRequired()
                .HasMaxLength(100);
                
                p.Property(p=> p.Description)
                .IsRequired()
                .HasMaxLength(250);

                p.HasMany(p=> p.StockMovements) 
                .WithOne(sm => sm.Product) 
                .HasForeignKey(sm => sm.ProductId); 
            }
            );

            builder.Entity<StockMovement>(sm =>{
                sm.HasKey(sm => sm.Id);

                sm.Property(sm => sm.Quantity)
                .IsRequired();

                sm.Property(sm => sm.MovementDate)
                .IsRequired();

                sm.Property(sm => sm.Type)
                .IsRequired();

                sm.Property(sm => sm.Reason)
                .HasMaxLength(255);

                sm.Property(sm => sm.BatchNumber)
                .HasMaxLength(255);
            });
        }
    }
}
