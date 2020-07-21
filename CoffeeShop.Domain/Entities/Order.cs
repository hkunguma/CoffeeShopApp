using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoffeeShop.Domain.Entities
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails = new HashSet<OrderDetail>();
        }

        [DisplayName("OrderId")]
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
