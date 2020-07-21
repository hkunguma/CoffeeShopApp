using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using CoffeeShop.Domain.Entities;

namespace CoffeeShop.BLL.Models
{
    public class ClientModel
    {        
        public int Id { get; set; }
        public string Code { get; set; }

        [DisplayName("ClientName")]
        public string Name { get; set; }

        public  ClientCoffeeModel ClientCoffee { get; set; }
        public PointModel Point { get; set; }
        public  ICollection<PointModel> Points { get; set; }
        public  ICollection<PointConvertModel> PointConverts { get; set; }
        public  ICollection<OrderModel> Orders { get; set; }

        public int TotalPoints { get; set; }

        public static ClientModel ClientObj(Client client)
        {
            if (client != null)
                return new ClientModel
                {
                    Id = client.Id,
                    Code = client.Code,
                    Name = client.Name,
                    Points = new PointModel().PointModelObjList(client.Points.ToList()),
                    PointConverts = new PointConvertModel().PointConvertModelObjList(client.PointConverts.ToList())
                };

            return new ClientModel();
        }

        public static List<ClientModel> ClientObjList(List<Client> clients)
        {
            if (clients != null)
            {
                var clientModels = new List<ClientModel>();

                foreach (Client client in clients)
                {
                    clientModels.Add(ClientObj(client)); ;
                }
                return clientModels;
            }

            return new List<ClientModel>();
        }
    }
}
