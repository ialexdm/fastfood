using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fastfood.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int zeroCount = 0;
                new OrderItem(1, zeroCount, 0m);
            });

        }
        [Fact]
        public void OrderItem_WithNegativeCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int negativeCount = -1;
                new OrderItem(1, negativeCount, 0m);
            });
        }
        [Fact]
        public void OrderItem_WithPositiveCount_SetsCount()
        {
            var orderItem = new OrderItem(1, 2, 3m);
            Assert.Equal(1, orderItem.DishId);
            Assert.Equal(2, orderItem.Count);
            Assert.Equal(3m, orderItem.Price);

        }
    }
}
