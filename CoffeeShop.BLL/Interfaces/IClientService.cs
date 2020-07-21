using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using CoffeeShop.BLL.Models;

namespace CoffeeShop.BLL.Interfaces
{
    public interface IClientService
    {
        Task<List<ClientModel>> GetClients();
        Task<int> GetClientTotalPoints(int clientId);
    }
}
