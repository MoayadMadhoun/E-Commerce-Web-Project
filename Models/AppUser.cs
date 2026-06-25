using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Address { get; set; } = "Gaza";

        public bool IsActive { get; set; } = true;

        public string FullName { get; set; }

        public string ProfileImageUrl { get; set; } = "../../../images/account/default.png";

    }
}
