using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fastfood
{
    public class DishService
    {
        private readonly IDishRepository dishRepository;
        public DishService(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }
        public Dish[] GetAllByQuery(string query)
        {
            Dish[] dishes;
            if (Dish.IsTtk(query))
            {
                dishes = this.dishRepository.GetByTtk(query);
            }
            else
            {
                dishes = this.dishRepository.GetAllByNameOrCategory(query);
            }
            return dishes;
        }
    }
}
