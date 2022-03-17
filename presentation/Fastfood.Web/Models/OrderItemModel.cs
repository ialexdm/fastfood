namespace Fastfood.Web.Models
{
    public class OrderItemModel
    {
        public int DishId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Count { get; set; }

        public decimal Price { get; set; }
    }
}
