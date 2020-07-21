using System;
using System.Collections.Generic;
using System.Text;

using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BLL.Models
{
    public class PointConvertModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PointQuantity { get; set; }
        public decimal Amount { get; set; }
        public Nullable<DateTime> ConvertedDate { get; set; }

        public ClientModel Client { get; set; }

        public PointConvertModel PointConvertModelObj(PointConvert pointConvert)
        {
            if (pointConvert != null)
                return new PointConvertModel
                {
                    Id = pointConvert.Id,
                    ClientId = pointConvert.ClientId,
                    PointQuantity = pointConvert.PointQuantity,
                    Amount = pointConvert.Amount,
                    ConvertedDate = pointConvert.ConvertedDate
                };

            return new PointConvertModel();
        }

        public List<PointConvertModel> PointConvertModelObjList(List<PointConvert> pointConverts)
        {
            if (pointConverts != null)
            {
                var pointConvertModels = new List<PointConvertModel>();

                foreach (PointConvert pointConvert in pointConverts)
                {
                    pointConvertModels.Add(PointConvertModelObj(pointConvert));
                }
                return pointConvertModels;
            }

            return new List<PointConvertModel>();
        }
    }
}
