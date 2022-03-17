using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fastfood
{
    public class OrderItem
    {
        public int DishId { get; }
        public int Count { get; }

        public decimal Price { get; }//this propety keep a price which was correct when dish was ordered. Same dishes was ordered in diferent times can has different price.
        public OrderItem(int dishId, int count, decimal price)
        {
            if(count <= 0)
            {
                throw new ArgumentOutOfRangeException("Count must be greater than zero ");
            }

            DishId = dishId;
            Count = count;
            Price = price;
        }
    }
}
