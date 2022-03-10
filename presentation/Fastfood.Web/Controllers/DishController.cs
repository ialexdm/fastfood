using Microsoft.AspNetCore.Mvc;


namespace Fastfood.Web.Controllers
{
    public class DishController : Controller
    {
        private readonly IDishRepository dishRepository;
        public DishController(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }
        public IActionResult Index(int id)
        {
            Dish dish = dishRepository.GetById(id);
            return View(dish);
        }
    }
}
