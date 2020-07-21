using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.Domain.Entities
{
    public class ClientCoffee
    {
        [Key]
        public int ClientId { get; set; }
        public int CoffeeQuantity { get; set; }
        public Nullable<DateTime> UpdateDate { get; set; }

        public virtual Client Client { get; set; }
    }
}
