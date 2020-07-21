using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CoffeeShop.BLL.Models;

namespace CoffeeShop.BLL.Interfaces
{
    public interface IPointService
    {
        void CalculatePointPerCoffeeBought(OrderModel orderModel);
        Task CreatePoint(int clientId, int pointQuantity);
        Task<decimal> ConvertAllocatedPointsToCash(int clientId, int pointQuantity, DateTime convertedDate);
    }
}
