using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CoffeeShop.BLL.Models;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;

namespace CoffeeShop.BLL.Services
{
    public class PointService : IPointService
    {
        private readonly ICoffeeShopApiClient _coffeeShopApiClient;
        public PointService(ICoffeeShopApiClient coffeeShopApiClient)
        {
            _coffeeShopApiClient = coffeeShopApiClient;
        }

        /// <summary>
        /// Get pointQuantity for every coffeeQuantity bought
        /// </summary>
        /// <param name="orderModel"></param>
        public async void  CalculatePointPerCoffeeBought(OrderModel orderModel)
        {
            var clientCoffeeBought = await GetClientCoffeeBought(orderModel.ClientId);

            var coffeePointWorth = await GetCoffeePointWorth();

            int points = 0;

            foreach (OrderDetailModel orderDetailModel in orderModel.OrderDetails)
            {
                points = CalculatePoints(ref clientCoffeeBought, coffeePointWorth, orderDetailModel);

                await CreatePoint(orderModel.ClientId, points);
            }

            await UpdateClientCoffeeBought(clientCoffeeBought);
        }

        public async Task CreatePoint(int clientId,int pointQuantity)
        {
            Point point = new Point
            {
                ClientId = clientId,
                CreateDate = DateTime.Now,
                Quantity = pointQuantity
            };

            await _coffeeShopApiClient.CreatePoint(point);
        }

        /// <summary>
        /// -- pointQuantity is worth value equal to R:amount for a total quantity of coffess bought <= coffeeQuantity,
        /// -- pointQuantity is worth value equal to(R:amount + R1) for a total quantity of coffess bought > coffeeQuantity AND < (coffeeQuantity* 2),
        /// -- pointQuantity is worth value equal to(R:amount + R2) for a total quantity of coffess bought > (coffeeQuantity * 2),
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="pointQuantity"></param>
        /// <returns></returns>

        public async Task<decimal> ConvertAllocatedPointsToCash(int clientId, int pointQuantity, DateTime convertedDate)
        {
            PointWorth pointWorth = await GetPointWorth();

            int coffeeOrderQuantity = await GetCoffeeOrderQuantity(clientId);

            decimal pointsCash = ConvertPointToCash(pointWorth, coffeeOrderQuantity, pointQuantity);

            var pointConvert = new PointConvert {
                ClientId = clientId,
                PointQuantity = pointQuantity,
                Amount = pointsCash,
                ConvertedDate = convertedDate
            };

            await CreateConvertedPoints(pointConvert);

            return pointsCash;
        }

        private decimal ConvertPointToCash(PointWorth pointWorth, int coffeeOrderQuantity, int pointQuantity)
        {
            decimal pointValue = 0.0m;

            if(coffeeOrderQuantity <= pointWorth.CoffeeQuantity)
            {
                pointValue = pointWorth.Amount;
            }else if(coffeeOrderQuantity < (pointWorth.CoffeeQuantity*2))
            {
                pointValue = pointWorth.Amount + 1;
            }else if(coffeeOrderQuantity >= (pointWorth.CoffeeQuantity * 2))
            {
                pointValue = pointWorth.Amount + 2;
            }


            return (pointValue * (pointQuantity/pointWorth.PointQuantity));
        }

        private int CalculatePoints(ref ClientCoffee clientCoffee, CoffeePointWorth coffeePointWorth,
            OrderDetailModel orderDetailModel)
        {
            var currentQuantity = (orderDetailModel.Quantity + clientCoffee.CoffeeQuantity);

            int points = (int)(currentQuantity / coffeePointWorth.CoffeeQuantity);

            int remainderCoffeeQuantity = (int)(currentQuantity % coffeePointWorth.CoffeeQuantity);

            clientCoffee.CoffeeQuantity = remainderCoffeeQuantity;

            return points;
        }

        
        private async Task<ClientCoffee> GetClientCoffeeBought(int clientId)
        {
            var clientCoffee = await _coffeeShopApiClient.GetClientCoffeeBought(clientId);

            if(clientCoffee == null)
            {
                await CreateClientCoffeeBoughtTrack(clientId);
                clientCoffee = await _coffeeShopApiClient.GetClientCoffeeBought(clientId);
            }
            return clientCoffee;
        }
        private async Task CreateClientCoffeeBoughtTrack(int clientId)
        {
            await _coffeeShopApiClient.CreateClientCoffee(new ClientCoffee {
                ClientId = clientId, CoffeeQuantity = 0, UpdateDate = DateTime.Now });
        }
        private async Task UpdateClientCoffeeBought(ClientCoffee clientCoffee)
        {
             await _coffeeShopApiClient.UpdateClientCoffee(clientCoffee);            
        }

        private async Task<CoffeePointWorth> GetCoffeePointWorth()
        {
            var coffeePointWorth = await _coffeeShopApiClient.GetCoffeePointWorth();
            return coffeePointWorth;
        }

        private async Task<PointWorth> GetPointWorth()
        {
            var pointWorth = await _coffeeShopApiClient.GetPointWorth();
            return pointWorth;
        }

        private async Task<int> GetCoffeeOrderQuantity(int clientId)
        {
            var orders = await GetOrders(clientId);

            int coffeeOrderQuantity = 0;

            if (orders!=null)
            {
                coffeeOrderQuantity = orders.SelectMany(o => o.OrderDetails).Sum(d => d.Quantity);
            }

            return coffeeOrderQuantity;
        }
        private async Task<List<Order>> GetOrders(int clientId)
        {
            var orders = await _coffeeShopApiClient.GetOrders(clientId);
            return orders;
        }

        private async Task CreateConvertedPoints(PointConvert pointConvert)
        {
            await _coffeeShopApiClient.CreateConvertedPoints(pointConvert);
        }

    }
}
