using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CoffeeShop.BLL.Models;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace CoffeeShop.BLL.Services
{
    public class ClientService : IClientService
    {
        private readonly ICoffeeShopApiClient _coffeeShopApiClient;
        public ClientService(ICoffeeShopApiClient coffeeShopApiClient)
        {
            _coffeeShopApiClient = coffeeShopApiClient;
        }

        public async Task<List<ClientModel>> GetClients()
        {
            var clientList = await _coffeeShopApiClient.GetClients();
            List<ClientModel> clients = ClientModel.ClientObjList(clientList);

            clients.ToList().ForEach(c => c.TotalPoints = (c.Points.Sum(p => p.Quantity) - c.PointConverts.Sum(x=>x.PointQuantity)));

            return clients; 
        }

        public async Task<int> GetClientTotalPoints(int clientId)
        {
            var clientList = await _coffeeShopApiClient.GetClients();
            var client = clientList.Where(x => x.Id == clientId).FirstOrDefault();
            ClientModel clientModel = ClientModel.ClientObj(client);

            clientModel.TotalPoints = clientModel.Points.Sum(p => p.Quantity) - clientModel.PointConverts.Sum(x => x.PointQuantity);

            return clientModel.TotalPoints;
        }

    }
}
