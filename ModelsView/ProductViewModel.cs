using MyStore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MyStore.ModelsView
{
    public class ProductViewModel
    {
        [Key]
        public int ProductId { get; set; }

        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "allowed string between 5 and 100")]
        public string Name { get; set; }
        [Range(0,999999)]
        public double Price { get; set; }
        [Range(0, 999999)]
        [DisplayName("Stock Quantity")]
        public int StockQuantity { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Main Image")]
        public IFormFile? Image { get; set; }
        public string? ImageUrl { get; set; }
        public string? Publisher { get; set; }
    }
}
