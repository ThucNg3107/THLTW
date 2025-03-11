using System.ComponentModel.DataAnnotations;

namespace NguyenHienThuc_2280603165.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
    }
}
