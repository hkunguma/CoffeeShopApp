using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Domain.Interfaces
{
    public interface ICoffeeShopApiClient
    {
        #region //Order

        Task CreateOrder(Domain.Entities.Order order);
        Task<List<Domain.Entities.Order>> GetOrders(int clientId);

        #endregion //Order 

        #region //Client

        Task<List<Domain.Entities.Client>> GetClients();

        #endregion //Client

        #region //Point

        //Task<List<Domain.Entities.Point>> GetPointsByClientId(int id);

        Task CreatePoint(Domain.Entities.Point point);

        #endregion //Point

        #region //PointConvert

        //Task<List<Domain.Entities.Point>> GetConvertedPoints(int id);

        Task CreateConvertedPoints(Domain.Entities.PointConvert pointConvert);

        #endregion //PointConvert

        #region //ClientCoffee

        Task<Domain.Entities.ClientCoffee> GetClientCoffeeBought(int id);

        Task CreateClientCoffee(Domain.Entities.ClientCoffee clientCoffee);

        Task UpdateClientCoffee(Domain.Entities.ClientCoffee clientCoffee);

        #endregion //ClientCoffee

        #region //PointWorth

        Task<Domain.Entities.PointWorth> GetPointWorth();

        #endregion //PointWorth

        #region //CoffeePointWorth

        Task<Domain.Entities.CoffeePointWorth> GetCoffeePointWorth();

        #endregion //CoffeePointWorth
    }
}
