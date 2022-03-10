using Fastfood.Web.Models;
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
        public CartController(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }
        public IActionResult Add(int id)
        {
            var dish = dishRepository.GetById(id);
            Cart cart;
            if(!HttpContext.Session.TryGetCart(out cart))
            {
                cart = new Cart();
            }
            if(cart.Items.ContainsKey(id))
            {
                cart.Items[id]++;
                
            }
            else
            {
                cart.Items[id] = 1;
            }
            cart.Amount += dish.Price;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Dish", new {id = id});
        }
    }
}
