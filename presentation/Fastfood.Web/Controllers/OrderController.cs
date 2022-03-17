using Fastfood.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fastfood.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDishRepository dishRepository;
        private readonly IOrderRepository orderRepository;
        public OrderController(IDishRepository dishRepository, IOrderRepository orderRepository)
        {
            this.dishRepository = dishRepository;
            this.orderRepository = orderRepository;
        }
        private OrderModel Map(Order order)
        {
            var dishIds = order.Items.Select(item => item.DishId);
            var dishes = dishRepository.GetAllByIds(dishIds);
            var itemModels = from item in order.Items
                             join dish in dishes on item.DishId equals dish.Id
                             select new OrderItemModel
                             {
                                 DishId = dish.Id,
                                 Name = dish.Name,
                                 Category = dish.Category,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderModel model = Map(order);

                return View(model);
            }
            return View("Empty");
        }

        public IActionResult AddItem(int id)
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
