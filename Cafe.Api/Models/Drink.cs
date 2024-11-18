using System.ComponentModel.DataAnnotations;



namespace Cafe.Api.Models
{
    public class Drink
    {
        [Key]
        public int Id { get; set; }

        public string DrinkName { get; set; } = string.Empty;  // Corrected typo

        public decimal Price { get; set; }

        public string Description { get; set; } = string.Empty;
        public string Size { get; set; } = "Medium";
        public bool IsAvailable { get; set; } = true;
        public bool IsHot { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
