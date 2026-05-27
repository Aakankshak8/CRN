using System.ComponentModel.DataAnnotations;

namespace Crn_Api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}