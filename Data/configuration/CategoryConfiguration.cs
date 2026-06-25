using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Models;

namespace MyStore.Data.configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(pr => pr.ImageUrl).HasDefaultValue("cat.png");
            //builder.HasData(new List<Category>
            //{
            //    new Category{CategoryId=1,Name="food",ImageUrl="cat.png"}
            //});
            builder.HasData(
                new List<Category>
                {
                    new Category { CategoryId = 1, Name = "Electronics", ImageUrl = "https://picsum.photos/seed/electronics/400/300" },
              new Category { CategoryId = 2, Name = "Home Appliances", ImageUrl = "https://picsum.photos/seed/home/400/300" },
              //new Category { CategoryId = 3, Name = "Mobile Accessories", ImageUrl = "https://picsum.photos/seed/mobile/400/300" },
              new Category { CategoryId = 4, Name = "Computer Devices", ImageUrl = "https://picsum.photos/seed/computer/400/300" },
              new Category { CategoryId = 5, Name = "Gaming", ImageUrl = "https://picsum.photos/seed/gaming/400/300" },
              new Category { CategoryId = 6, Name = "Office Supplies", ImageUrl = "https://picsum.photos/seed/office/400/300" },
              new Category { CategoryId = 7, Name = "Smart Wearables", ImageUrl = "https://picsum.photos/seed/wearables/400/300" },
              new Category { CategoryId = 8, Name = "Kitchen Tools", ImageUrl = "https://picsum.photos/seed/kitchen/400/300" },
              new Category { CategoryId = 9, Name = "Sports Equipment", ImageUrl = "https://picsum.photos/seed/sports/400/300" },
              new Category { CategoryId = 10, Name = "Health Products", ImageUrl = "https://picsum.photos/seed/health/400/300" },
              new Category { CategoryId = 11, Name = "Beauty Products", ImageUrl = "https://picsum.photos/seed/beauty/400/300" },
              new Category { CategoryId = 12, Name = "Car Accessories", ImageUrl = "https://picsum.photos/seed/car/400/300" },
              new Category { CategoryId = 13, Name = "Books", ImageUrl = "https://picsum.photos/seed/books/400/300" },
              new Category { CategoryId = 14, Name = "Music Instruments", ImageUrl = "https://picsum.photos/seed/music/400/300" },
              new Category { CategoryId = 15, Name = "Camera Gear", ImageUrl = "https://picsum.photos/seed/camera/400/300" },
              new Category { CategoryId = 16, Name = "Kids Toys", ImageUrl = "https://picsum.photos/seed/toys/400/300" },
              new Category { CategoryId = 17, Name = "Fashion", ImageUrl = "https://picsum.photos/seed/fashion/400/300" },
              new Category { CategoryId = 18, Name = "Outdoor", ImageUrl = "https://picsum.photos/seed/outdoor/400/300" },
              new Category { CategoryId = 19, Name = "Pet Supplies", ImageUrl = "https://picsum.photos/seed/pets/400/300" },
              new Category { CategoryId = 20, Name = "Cleaning Tools", ImageUrl = "https://picsum.photos/seed/cleaning/400/300" }
                }
              
          );
        }
    }
}
