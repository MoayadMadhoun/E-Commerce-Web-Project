using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class ProductImages
    {
        [Key]
        public int ProductImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
