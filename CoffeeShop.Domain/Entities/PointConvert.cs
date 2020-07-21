using System;

namespace CoffeeShop.Domain.Entities
{
    public class PointConvert
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PointQuantity { get; set; }
        public decimal Amount { get; set; }
        public Nullable<DateTime> ConvertedDate { get; set; }

        //public virtual Client Client { get; set; }
    }
}
