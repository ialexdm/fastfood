using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fastfood.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly DishService dishService;
        public SearchController(DishService dishService)
        {
            this.dishService = dishService;
        }
        public IActionResult Index(string query)
        {
            var dishes = this.dishService.GetAllByQuery(query);
            return View(dishes);
        }
    }
}
