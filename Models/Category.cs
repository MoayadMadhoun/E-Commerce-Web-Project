using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyStore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "allowed string between 5 and 100")]
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }


    }
}
