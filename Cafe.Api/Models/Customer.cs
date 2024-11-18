using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cafe.Api.Models
{

    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public int DrinksId { get; set; }
        public int SnacksId { get; set; }

        [JsonIgnore]

        public List<Drink>? Drinks { get; set; }
        [JsonIgnore]
        public List<Snack>? Snacks { get; set; }


    }
}