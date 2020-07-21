using System;
using System.Collections.Generic;
using System.ComponentModel;

using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BLL.Models
{
    public class PointModel
    {
        [DisplayName("PointId")]
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Quantity { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }

        public ClientModel Client { get; set; }

        public PointModel PointModelObj(Point point)
        {
            if (point != null)
                return new PointModel
                {
                    Id = point.Id,
                    ClientId = point.ClientId,
                    Quantity = point.Quantity,
                    CreateDate = point.CreateDate
                };
            
            return new PointModel();
        }

        public List<PointModel> PointModelObjList(List<Point> points)
        {
            if (points != null)
            {
                var pointModels = new List<PointModel>();

                foreach (Point point in points)
                {
                    pointModels.Add(PointModelObj(point));
                }
                return pointModels;
            }

            return new List<PointModel>();
        }
    }
}
