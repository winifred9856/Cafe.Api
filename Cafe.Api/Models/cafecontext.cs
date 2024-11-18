
using Cafe.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Api.Models
{
    public class cafecontext : DbContext
    {
        public cafecontext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Drink> Drink { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<orderItem> orderItem { get; set; }

        public DbSet <Snack> Snack { get; set; }




    }
}
