using System;
using System.Linq;

namespace Fastfood.Memory
{
    public class DishRepository : IDishRepository
    {
        private readonly Dish[] dishes = new[]
        {
            new Dish(1, "Pizza Margarita"),
            new Dish(2, "Pizza Peperoni"),
            new Dish(3, "Pizza Three Cheeses"),
            new Dish(4, "Caesar salad")
        };
        public Dish[] GetAllByTitle(string titlePart)
        {
            return dishes.Where(dish => dish.Name.ToLower().Contains(titlePart)).ToArray();
        }
    }
}
