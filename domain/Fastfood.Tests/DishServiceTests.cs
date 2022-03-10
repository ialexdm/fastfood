using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Fastfood.Tests
{
    public class DishServiceTests
    {
        [Fact]
        public void GetAllByQuery_WithTtk_CallsGetByTtk()
        {
            var idOfTtkSearch = 1;
            var idOfNameOrCategorySearch = 2;
            var dishRepositoryStub = new Mock<IDishRepository>();
            dishRepositoryStub.Setup(x => x.GetByTtk(It.IsAny<string>()))
                .Returns(new[] { new Dish(idOfTtkSearch, "", "", "", "", 1.00m) });

            dishRepositoryStub.Setup(x => x.GetAllByNameOrCategory(It.IsAny<string>()))
                .Returns(new[] { new Dish(idOfNameOrCategorySearch, "", "", "", "", 1.00m) });

            var dishService = new DishService(dishRepositoryStub.Object);
            var validTtk = "TtK 1234";

            var actual = dishService.GetAllByQuery(validTtk);
            Assert.Collection(actual, dish => Assert.Equal(1, dish.Id));
        }
        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByNameOrCategory()
        {
            var idIfTtk = 1;
            var ifIfNameOrCategory = 2;
            var dishRepositoryStub = new Mock<IDishRepository>();
            dishRepositoryStub.Setup(x => x.GetByTtk(It.IsAny<string>()))
                .Returns(new[] { new Dish(idIfTtk, "", "", "", "", 0m) });

            dishRepositoryStub.Setup(x => x.GetAllByNameOrCategory(It.IsAny<string>()))
                .Returns(new[] { new Dish(ifIfNameOrCategory, "", "", "", "", 0m) });

            var dishService = new DishService(dishRepositoryStub.Object);
            var invalidTtk = "1234ttk";

            var actual = dishService.GetAllByQuery(invalidTtk);
            Assert.Collection(actual, dish => Assert.Equal(2, dish.Id));
        }
    }
}
