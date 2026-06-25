using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Models;

namespace MyStore.Data.configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(pr => pr.Updated).HasDefaultValueSql("getdate()");
            builder.Property(pr => pr.StockQuantity).HasDefaultValue("10");
            builder.HasIndex(c => c.Name).IsUnique();

            builder.HasMany(p => p.ProductImages).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).OnDelete(DeleteBehavior.Cascade);

            //builder.HasData(new List<Product>() {
            //    new Product{ ProductId=1, Name="p1", Price=49, StockQuantity=10, ImageUrl = "/images/products/default.jpg", CategoryId=1}
            //});

            builder.HasData(
               new Product { ProductId = 1, Name = "Wireless Mouse", Price = 25.5, StockQuantity = 50, ImageUrl = "https://picsum.photos/seed/mouse/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 10), CategoryId = 4 },
               new Product { ProductId = 2, Name = "Mechanical Keyboard", Price = 75, StockQuantity = 30, ImageUrl = "https://picsum.photos/seed/keyboard/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 12), CategoryId = 4 },
               new Product { ProductId = 3, Name = "Smart Watch", Price = 120, StockQuantity = 20, ImageUrl = "https://picsum.photos/seed/watch/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 15), CategoryId = 7 },
               new Product { ProductId = 4, Name = "Bluetooth Headphones", Price = 60, StockQuantity = 40, ImageUrl = "https://picsum.photos/seed/headphones/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 18), CategoryId = 1 },
               new Product { ProductId = 5, Name = "USB-C Charger", Price = 18, StockQuantity = 100, ImageUrl = "https://picsum.photos/seed/charger/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 20), CategoryId = 4 },
               new Product { ProductId = 6, Name = "Gaming Controller", Price = 55, StockQuantity = 35, ImageUrl = "https://picsum.photos/seed/controller/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 22), CategoryId = 5 },
               new Product { ProductId = 7, Name = "Office Chair", Price = 150, StockQuantity = 10, ImageUrl = "https://picsum.photos/seed/chair/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 25), CategoryId = 6 },
               new Product { ProductId = 8, Name = "Laptop Cooling Pad", Price = 30, StockQuantity = 45, ImageUrl = "https://picsum.photos/seed/cooling/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 27), CategoryId = 4 },
               new Product { ProductId = 9, Name = "Camera Lens", Price = 220, StockQuantity = 8, ImageUrl = "https://picsum.photos/seed/lens/400/300", IsDeleted = false, Updated = new DateTime(2025, 1, 29), CategoryId = 15 },
               new Product { ProductId = 10, Name = "TV Remote", Price = 15, StockQuantity = 60, ImageUrl = "https://picsum.photos/seed/remote/400/300", IsDeleted = false, Updated = new DateTime(2025, 2, 1), CategoryId = 1 },
               new Product { ProductId = 11, Name = "Kitchen Blender", Price = 95, StockQuantity = 12, ImageUrl = "https://picsum.photos/seed/blender/400/300", IsDeleted = false, Updated = new DateTime(2025, 2, 3), CategoryId = 8 },
               new Product { ProductId = 12, Name = "Dumbbells Set", Price = 40, StockQuantity = 25, ImageUrl = "https://picsum.photos/seed/dumbbells/400/300", IsDeleted = false, Updated = new DateTime(2025, 2, 5), CategoryId = 9 },
               new Product { ProductId = 13, Name = "Car Phone Holder", Price = 12, StockQuantity = 70, ImageUrl = "https://picsum.photos/seed/carholder/400/300", IsDeleted = false, Updated = new DateTime(2025, 2, 6), CategoryId = 12 },
               new Product { ProductId = 14, Name = "Toy Car", Price = 20, StockQuantity = 80, ImageUrl = "https://picsum.photos/seed/toycar/400/300", IsDeleted = false, Updated = new DateTime(2025, 2, 7), CategoryId = 16 }
               );
        }
    }
}
