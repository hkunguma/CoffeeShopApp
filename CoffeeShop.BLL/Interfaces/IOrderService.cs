using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CoffeeShop.BLL.Models;

namespace CoffeeShop.BLL.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrder(OrderModel orderModel);
    }
}
