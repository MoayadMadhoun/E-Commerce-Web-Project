using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required,StringLength(100,MinimumLength =5, ErrorMessage ="allowed string between 5 and 100")]
        public string Name { get; set; }
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "allowed string between 5 and 100")]
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        [NotMapped]
        public string PriceStr { get => $"{Price} <img src=\"/images/icons/shekel.jpg\" width='16' />"; }
        public int StockQuantity { get; set; } 
        [Column("LastUpdate", TypeName ="date")]
        public DateTime Updated { get; set; }
        public bool IsDeleted { get; set; }
       

        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category? category { get; set; }
        public ICollection<ProductImages>? ProductImages { get; set; }


        public string? Publiser { get; set; }
    }
}
