using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CoffeeShop.Domain.Entities
{
    public class Client
    {
        public Client()
        {
            this.Orders = new HashSet<Order>();
            this.PointConverts = new HashSet<PointConvert>();
            this.Points = new HashSet<Point>();
        }

        public int Id { get; set; }
        public string Code { get; set; }

        [DisplayName("ClientName")]
        public string Name { get; set; }

        public virtual ClientCoffee ClientCoffee { get; set; }
        public virtual ICollection<Point> Points { get; set; }
        public virtual ICollection<PointConvert> PointConverts { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
