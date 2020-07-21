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
    public class PointController : Controller
    {
        private readonly IClientService _clientService;
        private readonly IPointService _pointService;
        public PointController(IClientService clientService, IPointService pointService)
        {
            _clientService = clientService;
            _pointService = pointService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Convert()
        {
            await PopulateClientDropDownList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Convert([Bind(include: "ClientId,PointQuantity,ConvertedDate")]
        PointConvertModel pointConvertModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int totalPointsAvailable = await _clientService.GetClientTotalPoints(pointConvertModel.ClientId);

                    if (pointConvertModel.PointQuantity <= totalPointsAvailable)
                    {
                        if (pointConvertModel.ConvertedDate == null)
                            pointConvertModel.ConvertedDate = DateTime.Now;

                        var amountConverted = await _pointService.ConvertAllocatedPointsToCash(pointConvertModel.ClientId,
                            pointConvertModel.PointQuantity, (DateTime)pointConvertModel.ConvertedDate);

                        pointConvertModel.Amount = amountConverted;

                        //return RedirectToAction(nameof(Index));
                        return View("Index", pointConvertModel);

                    }
                }
            }
            catch (Exception)
            {

            }

            await PopulateClientDropDownList(pointConvertModel.ClientId);
            return View();
        }

        private async Task PopulateClientDropDownList(object selectedClients = null)
        {
            var clients = await _clientService.GetClients();
            ViewBag.ClientList = new SelectList(clients, "Id", "Name", selectedClients);
        }
    }
}