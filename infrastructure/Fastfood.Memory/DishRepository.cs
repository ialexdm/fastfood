using System;
using System.Linq;

namespace Fastfood.Memory
{
    public class DishRepository : IDishRepository
    {
        private readonly Dish[] dishes = new[]
        {
            new Dish(1,
                "Margherita",
                "Pizza",
                "TTK 2117"),
            new Dish(2,
                "Pepperoni",
                "Pizza",
                "TTK 2115"),
            new Dish(3,
                "Three Cheeses",
                "Pizza",
                "TTK 2281"),
            new Dish(4,
                "Caesar",
                "Salad",
                "TTK 3131")
        };

        public Dish[] GetAllByNameOrCategory(string query)
        {
            return dishes.Where(dish => dish.Category.ToLower().Contains(query.ToLower()) ||
            dish.Name.ToLower().Contains(query.ToLower())).ToArray();
        }

        public Dish[] GetByTtk(string ttk)
        {
            return dishes.Where(dish => dish.Ttk.Replace(" ","") == ttk.Replace(" ","").Replace("-","").ToUpper()).ToArray();
        }
    }
}
