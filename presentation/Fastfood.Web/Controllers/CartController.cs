﻿using Fastfood.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fastfood.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IDishRepository dishRepository;
        private readonly IOrderRepository orderRepository;
        public CartController(IDishRepository dishRepository, IOrderRepository orderRepository)
        {
            this.dishRepository = dishRepository;
            this.orderRepository = orderRepository;
        }
        public IActionResult Add(int id)
        {

            Order order;
            Cart cart;
            if(HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }
            var dish = dishRepository.GetById(id);
            order.AddItem(dish, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Dish", new {id = id});
        }
    }
}
