

using System.ComponentModel.DataAnnotations;


namespace Cafe.Api.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }  // Primary key
        public DateTime OrderDate { get; set; } = DateTime.Now;  // Timestamp for when the order was placed
        public int CustomerId { get; set; }  // Foreign key to the Customer

        // Navigation property to link to the Customer
        public Customer Customer { get; set; }

        // Navigation property to the order items
        public List<orderItem> orderItem { get; set; } = new List<orderItem>();  // List of items in the order

        public decimal TotalPrice { get; set; }  // Total price of the order
        public string Status { get; set; } = "Pending";  // Order status: Pending, Completed, Canceled, etc.
    }

    public class orderItem
    {
        [Key]
        public int Id { get; set; }  // Primary key
        public int OrderId { get; set; }  // Foreign key to the Order
        public int ItemId { get; set; }  // Foreign key to the Drink or Snack
        public int Quantity { get; set; }  // Quantity of the item ordered
        public decimal Price { get; set; }  // Price per item

        // Navigation properties
        public Order Order { get; set; }
        public Drink Drink { get; set; }
        public Snack Snack { get; set; }
    }


}
