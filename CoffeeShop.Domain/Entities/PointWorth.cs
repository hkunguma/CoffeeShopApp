using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShop.Domain.Entities
{
    /// <summary>
    /// lookup table on how to calcualte points worth based on amount of coffee bought
    /// -- pointQuantity is worth value equal to R:amount for a total quantity of coffess bought <= coffeeQuantity,
    /// -- pointQuantity is worth value equal to(R:amount + R1) for a total quantity of coffess bought > coffeeQuantity AND < (coffeeQuantity* 2),
    /// -- pointQuantity is worth value equal to(R:amount + R2) for a total quantity of coffess bought > (coffeeQuantity * 2),
    /// </summary>
    public class PointWorth
    {
        public int Id { get; set; }
        public int PointQuantity { get; set; }
        public int CoffeeQuantity { get; set; }
        public decimal Amount { get; set; }
    }
}
