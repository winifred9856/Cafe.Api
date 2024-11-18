using System.ComponentModel.DataAnnotations;

namespace Cafe.Api.Models
{
    public class Snack
    {
        [Key]
        public int Id { get; set; }
        public string SnackName { get; set; } = string.Empty;  // Name of the snack
        public decimal Price { get; set; }

        // Suggested additional properties
        public string Description { get; set; } = string.Empty;  // Short description
        public bool IsAvailable { get; set; } = true;  // Availability status

        public string Size { get; set; } = "Regular";  // Portion size options: Small, Regular, Large
        public DateTime CreatedDate { get; set; } = DateTime.Now;  // Timestamp of creation
    }
}
