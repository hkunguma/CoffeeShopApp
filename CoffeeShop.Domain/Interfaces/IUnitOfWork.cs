using System;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<Client> ClientRepository { get; }
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        IGenericRepository<ClientCoffee> ClientCoffeeRepository { get; }
        IGenericRepository<CoffeePointWorth> CoffeePointWorthRepository { get; }
        IGenericRepository<Point> PointRepository { get; }
        IGenericRepository<PointConvert> PointConvertRepository { get; }
        IGenericRepository<PointWorth> PointWorthRepository { get; }
        void Save();
        void Dispose();
    }
}
