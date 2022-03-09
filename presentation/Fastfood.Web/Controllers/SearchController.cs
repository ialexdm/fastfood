using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fastfood.Memory;

namespace Fastfood.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly IDishRepository dishRepository;
        public SearchController(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }
        public IActionResult Index(string query)
        {
            var dishes = this.dishRepository.GetAllByTitle(query);
            return View(dishes);
        }
    }
}
