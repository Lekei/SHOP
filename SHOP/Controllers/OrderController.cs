﻿using AspNetApp.interfaces;
using AspNetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopSpate shopSpate;

        private readonly ILogger<OrderController> _logger;
        private readonly Service service;

        public OrderController(IAllOrders allOrders, ShopSpate shopSpate, Service service)
        {
            this.allOrders = allOrders;
            this.shopSpate = shopSpate;
            this.service = service;
        }

        public IActionResult CheckOut()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopSpate.listShopItems = shopSpate.getShopSpateItems();

            if (shopSpate.listShopItems.Count == 0)
            {
                ModelState.AddModelError("", "У вас должны быть товары!");
            }

            /* if (ModelState.IsValid)
             {*/
            allOrders.createOrder(order);
            service.SendEmail(order);
            return RedirectToAction("Complete");
            /* }*/

            return View(order);
        }

        public ViewResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

    }
}