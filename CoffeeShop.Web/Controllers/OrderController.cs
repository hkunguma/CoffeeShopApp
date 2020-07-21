using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoffeeShop.DAL.API.Client;
using CoffeeShop.Domain.Entities;
using CoffeeShop.Domain.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoffeeShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IClientService _clientService;
        private readonly IPointService _pointService;
        public OrderController(IOrderService orderService, IClientService clientService, IPointService pointService)
        {
            _orderService = orderService;
            _clientService = clientService;
            _pointService = pointService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Order/Create
        public async Task<IActionResult> Create()
        {
            await PopulateClientDropDownList();

            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "ClientId,OrderDate,OrderDetails")]OrderModel orderModel)//IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _orderService.CreateOrder(orderModel);
                    _pointService.CalculatePointPerCoffeeBought(orderModel);

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {

            }
            await PopulateClientDropDownList(orderModel.ClientId);
            return View();
        }

        private async Task PopulateClientDropDownList(object selectedClients = null)
        {
            var clients = await _clientService.GetClients();
            ViewBag.ClientList = new SelectList(clients, "Id", "Name", selectedClients);
        }

    }
}