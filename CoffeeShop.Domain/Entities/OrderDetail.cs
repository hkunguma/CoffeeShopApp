using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoffeeShop.Domain.Entities
{
    public class OrderDetail
    {
        [DisplayName("OrderDetailId")]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }

        //public virtual Order Order { get; set; }
    }
}
