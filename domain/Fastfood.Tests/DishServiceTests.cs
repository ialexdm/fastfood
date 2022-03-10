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
            var dishRepositoryStub = new Mock<IDishRepository>();
            dishRepositoryStub.Setup(x => x.GetByTtk(It.IsAny<string>()))
                .Returns(new[] { new Dish(1,"", "", "") });

            dishRepositoryStub.Setup(x => x.GetAllByNameOrCategory(It.IsAny<string>()))
                .Returns(new[] { new Dish(2, "", "", "") });

            var dishService = new DishService(dishRepositoryStub.Object);
            var validTtk = "TtK 1234";

            var actual = dishService.GetAllByQuery(validTtk);
            Assert.Collection(actual, dish => Assert.Equal(1, dish.Id));
        }
        [Fact]
        public void GetAllByQuery_WithAuthor_CallsGetAllByNameOrCategory()
        {
            var dishRepositoryStub = new Mock<IDishRepository>();
            dishRepositoryStub.Setup(x => x.GetByTtk(It.IsAny<string>()))
                .Returns(new[] { new Dish(1, "", "", "") });

            dishRepositoryStub.Setup(x => x.GetAllByNameOrCategory(It.IsAny<string>()))
                .Returns(new[] { new Dish(2, "", "", "") });

            var dishService = new DishService(dishRepositoryStub.Object);
            var invalidTtk = "1234ttk";

            var actual = dishService.GetAllByQuery(invalidTtk);
            Assert.Collection(actual, dish => Assert.Equal(2, dish.Id));
        }
    }
}
