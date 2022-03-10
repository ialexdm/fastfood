using System;
using Xunit;

namespace Fastfood.Tests
{
    public class DishTests
    {
        [Fact]
        public void IsTtk_WithNull_ReturnFalse()
        {
            bool actual = Dish.IsTtk(null);

            Assert.False(actual);
        }
        [Fact]
        public void IsTtk_WithBlankString_ReturnFalse()
        {
            bool actual = Dish.IsTtk("     ");

            Assert.False(actual);
        }
        [Fact]
        public void IsTtk_WithInvalidTtk_ReturnFalse()
        {
            bool actual = Dish.IsTtk("TTK 12");

            Assert.False(actual);
        }
        [Fact]
        public void IsTtk_WithTtk4_ReturnTrue()
        {
            bool actual = Dish.IsTtk("TTK 1545");

            Assert.True(actual);
        }
    }
}
