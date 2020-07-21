using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeShop.DAL.EF.Provider
{
    public static class DbInitializer
    {
        public static void Initialize(CoffeeShopContext context)
        {
            context.Database.EnsureCreated();

            //Look for any customers
            if (context.Clients.Any())
            {
                return; // DB has been seeded
            }
        }
    }
}
