using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Domain.Entities
{
    /// <summary>
    /// lookup table on how to calcualte points based on amount of coffee bought
    /// "Get pointQuantity for every coffeeQuantity bought"
    /// </summary>
    public class CoffeePointWorth
    {
        public int Id { get; set; }
        public int PointQuantity { get; set; }
        public int CoffeeQuantity { get; set; }
    }
}
