using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using CoffeeShop.BLL.Interfaces;
using CoffeeShop.BLL.Models;
using CoffeeShop.BLL.Services;

namespace CoffeeShop.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;           
        }

        public async Task<IActionResult> Index()
        {
            var clients = await _clientService.GetClients();

            return View(clients);
        }
    }
}