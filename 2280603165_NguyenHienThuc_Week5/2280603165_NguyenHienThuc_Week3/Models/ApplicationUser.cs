using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using Microsoft.AspNetCore.Identity;

namespace _2280603165_NguyenHienThuc_Week3.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Age {get; set; }
    }
}
