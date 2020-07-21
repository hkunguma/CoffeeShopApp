using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using CoffeeShop.BLL.Models;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;

namespace CoffeeShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly ICoffeeShopApiClient _coffeeShopApiClient;
        public OrderService(ICoffeeShopApiClient coffeeShopApiClient)
        {
            _coffeeShopApiClient = coffeeShopApiClient;
        }

        public async Task CreateOrder(OrderModel orderModel)
        {
            Order order = OrderModel.OrderObj(orderModel);

            await _coffeeShopApiClient.CreateOrder(order);
        }
    }
}
