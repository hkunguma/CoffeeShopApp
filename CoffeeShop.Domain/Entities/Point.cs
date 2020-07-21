using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Domain.Entities
{
    public class Point
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Quantity { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }

        //public virtual Client Client { get; set; } //circular reference
    }
}
