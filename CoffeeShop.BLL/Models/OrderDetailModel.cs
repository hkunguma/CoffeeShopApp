using System;
using System.Collections.Generic;
using System.ComponentModel;

using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BLL.Models
{
    public class OrderDetailModel
    {
        [DisplayName("OrderDetailId")]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }

        public OrderModel Order { get; set; }

        public OrderDetail OrderDetailObj(OrderDetailModel orderDetailModel)
        {
            if (orderDetailModel != null)
                return new OrderDetail
                {
                    Id = orderDetailModel.Id,
                    OrderId = orderDetailModel.OrderId,
                    Quantity = orderDetailModel.Quantity,
                    Price = orderDetailModel.Price,
                    ItemDescription = orderDetailModel.ItemDescription
                };

            return new OrderDetail();
        }

        public List<OrderDetail> OrderDetailObjList(List<OrderDetailModel> orderDetailModels)
        {
            if (orderDetailModels != null)
            {
                var orderDetails = new List<OrderDetail>();

                foreach(OrderDetailModel orderDetailModel in orderDetailModels)
                {
                    orderDetails.Add(OrderDetailObj(orderDetailModel));
                }
                return orderDetails;
            }

            return new List<OrderDetail>();
        }
        
    }
}
