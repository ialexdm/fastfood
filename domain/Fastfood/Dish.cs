using System;
using System.Text.RegularExpressions;

namespace Fastfood
{
    public class Dish
    {
        public int Id { get; }
        public string Name { get; }
        public string Category { get; }
        public string Ttk { get; }
        public string Description { get; }
        public decimal Price { get; }



        public Dish(int id, string name, string category, string ttk, string description, decimal price)
        {
            Id = id;
            Name = name;
            Category = category;
            Ttk = ttk;
            Description = description;
            Price = price;
        }

        internal static bool IsTtk(string s)
        {
            bool isTtk;
            if (s == null)
            {
                isTtk = false;
            }
            else
            {
                s = s.Replace("-", "")
                     .Replace(" ", "")
                     .ToUpper();
                
                isTtk = Regex.IsMatch(s, @"^TTK\d{4}$");
            }

            return isTtk;
        }
    }
}
