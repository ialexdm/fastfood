using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fastfood
{
    public interface IDishRepository
    {
        Dish[] GetAllByNameOrCategory(string nameOrCategory);
        Dish[] GetByTtk(string ttk);
        Dish GetById(int id);
        Dish[] GetAllByIds(IEnumerable<int> ids);
    }
}
