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
                "Pizza","TTK 2117",
                "is a typical Neapolitan pizza, made with San Marzano tomatoes, mozzarella cheese, fresh basil, salt, and extra-virgin olive oil.",
                500.00m),
            new Dish(2,
                "Pepperoni",
                "Pizza",
                "TTK 2115","According to Convenience Store Decisions, Americans consume 251.7 million pounds of pepperoni annually, on 36% of all pizzas produced nationally.",
                650.00m),
            new Dish(3,
                "Three Cheeses",
                "Pizza",
                "TTK 2281",
                "is a variety of pizza in Italian cuisine that is topped with a combination of four kinds of cheese, usually melted together, with (rossa, red) or without (bianca, white) tomato sauce. It is popular worldwide, including in Italy,[1] and is one of the iconic items from Pizzerias' menus.",
                750.00m),
            new Dish(4,
                "Caesar",
                "Salad",
                "TTK 3131",
                "is a green salad of romaine lettuce and croutons dressed with lemon juice (or lime juice), olive oil, egg, Worcestershire sauce, anchovies, garlic, Dijon mustard, Parmesan cheese, and black pepper.",
                350.00m)
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
