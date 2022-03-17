using System;
using System.Collections.Generic;
using System.Linq;

namespace Fastfood
{
    public class Order
    {
        public int Id { get; }

        private List<OrderItem> items;
        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }
        public int TotalCount
        {
            get { return items.Sum(item => item.Count); }
        }
        public decimal TotalPrice
        {
            get { return items.Sum(item => item.Count * item.Price); }
        }
        public Order(int id, IEnumerable<OrderItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }
            Id = id;

            this.items = new List<OrderItem>(items);
        }
        public void AddItem(Dish dish, int count)
        {
            //todo tests
            if ( dish == null)
            {
                throw new ArgumentNullException(nameof(dish));
            }

            var item = items.SingleOrDefault(d => d.DishId == dish.Id);
            if(item == null)
            {
                items.Add(new OrderItem(dish.Id, count, dish.Price));
            }
            else
            {
                items.Remove(item);
                items.Add(new OrderItem(dish.Id, item.Count + count, dish.Price));
            }

        }


    }
}
