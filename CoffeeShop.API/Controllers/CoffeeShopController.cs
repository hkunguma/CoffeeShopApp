using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CoffeeShop.DAL.EF.Provider;
using CoffeeShop.DAL.EF.Repository;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;

namespace CoffeeShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeShopController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoffeeShopController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region //Order

        [HttpGet("getOrders")]
        public async Task<List<Domain.Entities.Order>> GetOrders(int clientId)
        {
            return await Task.Run(() => _unitOfWork.OrderRepository.Get(
                o=>o.ClientId == clientId, includeProperties: "OrderDetails").ToList());
        }

        [HttpPost("createOrder")]
        public async Task CreateOrder(Domain.Entities.Order order)
        {
            await Task.Run(() => InsertOrder(order));
        }

        private void InsertOrder(Domain.Entities.Order order)
        {
            _unitOfWork.OrderRepository.Insert(order);
            _unitOfWork.OrderRepository.Save();
            //_unitOfWork.Save();
        }

        #endregion //Order 

        #region //Client

        [HttpGet("getClients")]
        public async Task<List<Domain.Entities.Client>> GetClients()
        {
            var clients = await Task.Run(() => _unitOfWork.ClientRepository.Get(includeProperties: "Points,PointConverts").ToList());
            return clients;
            
        }

        #endregion //Client

        #region //Point

        [HttpGet("getPointsByClientId")]
        public async Task<List<Domain.Entities.Point>> GetPoints(int id)
        {
            return await Task.Run(() => _unitOfWork.PointRepository.Get(p=>p.ClientId == id).ToList());
        }

        [HttpPost("createPoint")]
        public async Task CreatePoint(Domain.Entities.Point point)
        {
            await Task.Run(() => InsertPoint(point));
        }

        private void InsertPoint(Domain.Entities.Point point)
        {
            _unitOfWork.PointRepository.Insert(point);
            _unitOfWork.PointRepository.Save();
            //_unitOfWork.Save();
        }

        #endregion //Point

        #region //PointConvert

        [HttpGet("getConvertedPoints")]
        public async Task<List<Domain.Entities.PointConvert>> GetConvertedPoints(int id)
        {
            return await Task.Run(() => _unitOfWork.PointConvertRepository.Get(p => p.ClientId == id).ToList());
        }

        [HttpPost("createConvertedPoints")]
        public async Task CreateConvertedPoints(Domain.Entities.PointConvert pointConvert)
        {
            await Task.Run(() => InsertPointConvert(pointConvert));
        }

        private void InsertPointConvert(Domain.Entities.PointConvert pointConvert)
        {
            _unitOfWork.PointConvertRepository.Insert(pointConvert);
            _unitOfWork.PointConvertRepository.Save();            
        }

        #endregion //PointConvert

        #region //ClientCoffee

        [HttpGet("getClientCoffeeBought")]
        public async Task<Domain.Entities.ClientCoffee> GetClientCoffeeBought(int id)
        {
            return await Task.Run(() => _unitOfWork.ClientCoffeeRepository.GetByID(id));
        }

        [HttpPost("createClientCoffee")]
        public async Task CreateClientCoffee(Domain.Entities.ClientCoffee clientCoffee)
        {
            await Task.Run(() => InsertClientCoffee(clientCoffee));
        }

        private void InsertClientCoffee(Domain.Entities.ClientCoffee clientCoffee)
        {
            _unitOfWork.ClientCoffeeRepository.Insert(clientCoffee);
            _unitOfWork.ClientCoffeeRepository.Save();
        }

        [HttpPut("updateClientCoffee")]
        public async Task PutClientCoffee(Domain.Entities.ClientCoffee clientCoffee)
        {
            await Task.Run(() => UpdateClientCoffee(clientCoffee));
        }

        private void UpdateClientCoffee(Domain.Entities.ClientCoffee clientCoffee)
        {
            _unitOfWork.ClientCoffeeRepository.Update(clientCoffee);
            _unitOfWork.ClientCoffeeRepository.Save();
        }

        #endregion //ClientCoffee

        #region //PointWorth

        [HttpGet("getPointWorth")]
        public async Task<Domain.Entities.PointWorth> GetPointWorth()
        {
            return await Task.Run(() => _unitOfWork.PointWorthRepository.Get().FirstOrDefault());
        }

        #endregion //PointWorth

        #region //CoffeePointWorth

        [HttpGet("getCoffeePointWorth")]
        public async Task<Domain.Entities.CoffeePointWorth> GetCoffeePointWorth()
        {
            return await Task.Run(() => _unitOfWork.CoffeePointWorthRepository.Get().FirstOrDefault());
        }

        #endregion //CoffeePointWorth
    }
}