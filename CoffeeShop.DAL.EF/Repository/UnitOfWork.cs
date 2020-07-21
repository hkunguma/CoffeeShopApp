using System;
using System.Collections.Generic;
using System.Text;

using CoffeeShop.DAL.EF.Provider;
using CoffeeShop.Domain.Interfaces;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.DAL.EF.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CoffeeShopContext _context;

        public UnitOfWork(CoffeeShopContext context,IGenericRepository<Client> clientRepository, IGenericRepository<Order> orderRepository,
                          IGenericRepository<OrderDetail> orderdetailRepository, IGenericRepository<ClientCoffee> clientCoffeeRepository,
                          IGenericRepository<CoffeePointWorth> coffeePointWorthRepository, IGenericRepository<Point> pointRepository,
                          IGenericRepository<PointConvert> pointConvertRepository, IGenericRepository<PointWorth> pointWorthRepository)
        {
            _context = context;
            ClientRepository = clientRepository;
            OrderRepository = orderRepository;
            OrderDetailRepository = orderdetailRepository;
            ClientCoffeeRepository = clientCoffeeRepository;
            CoffeePointWorthRepository = coffeePointWorthRepository;
            PointRepository = pointRepository;
            PointConvertRepository = pointConvertRepository;
            PointWorthRepository = pointWorthRepository;
        }

        public IGenericRepository<Client> ClientRepository { get; }
        public IGenericRepository<Order> OrderRepository { get; }
        public IGenericRepository<OrderDetail> OrderDetailRepository { get; }
        public IGenericRepository<ClientCoffee> ClientCoffeeRepository { get; }
        public IGenericRepository<CoffeePointWorth> CoffeePointWorthRepository { get; }
        public IGenericRepository<Point> PointRepository { get; }
        public IGenericRepository<PointConvert> PointConvertRepository { get; }
        public IGenericRepository<PointWorth> PointWorthRepository { get; }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
