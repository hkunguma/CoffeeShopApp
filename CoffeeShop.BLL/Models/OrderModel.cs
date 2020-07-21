using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BLL.Models
{
    public class OrderModel
    {  
        public static Order OrderObj(OrderModel orderModel)
        {
            if (orderModel != null)
                return new Order
                {
                    Id = orderModel.Id,
                    ClientId = orderModel.ClientId,
                    OrderDate = orderModel.OrderDate,
                    OrderDetails = new OrderDetailModel().OrderDetailObjList(orderModel.OrderDetails.ToList())
                    //Client = orderModel.Client
                };

            return new Order();
        }
        
        [DisplayName("OrderId")]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Nullable<DateTime> OrderDate { get; set; }
        public ClientModel Client { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }
        public ICollection<OrderDetailModel> OrderDetails { get; set; }
    }
}
