using Cosmetics.Common;
using Cosmetics.Contracts;
using Cosmetics.Engine;
using Cosmetics.Products;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CosmeticsFactoryTests
    {
        [Test]
        public void CreateCategory_ShouldReturnInstanceOfClassCategory()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();

            mockedFactory.Setup(x => x.CreateCategory(It.IsAny<string>())).Returns(new Category("Toothpaste"));

            Assert.IsInstanceOf<ICategory>(mockedFactory.Object.CreateCategory("Toothpaste"));
        }

        [Test]
        public void CreateShampoo_ShouldReturnInstanceOfClassShampoo()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var shampoo = new Shampoo("Wash&Go","J&J",90m, GenderType.Men,250,UsageType.EveryDay);

            mockedFactory.Setup(x => x.CreateShampoo("Wash&Go", "J&J", 90m, GenderType.Men, 250, UsageType.EveryDay)).Returns(shampoo);

            Assert.AreEqual(shampoo, mockedFactory.Object.CreateShampoo("Wash&Go", "J&J", 90m, GenderType.Men, 250, UsageType.EveryDay));
        }

        [Test]
        public void CreateToothpaste_ShouldReturnInstanceOfClassToothPaste()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var toothpaste = new Toothpaste("WhiteFresh", "Colgate", 90m, GenderType.Men, new List<string>() { "polychlorid","menth"});

            mockedFactory.Setup(x => x.CreateToothpaste("White Fresh", "Colgate", 90m, GenderType.Men, new List<string>() { "polychlorid", "menth" })).Returns(toothpaste);

            Assert.AreEqual(toothpaste, mockedFactory.Object.CreateToothpaste("Wash&Go", "J&J", 90m, GenderType.Men, new List<string>() { "polychlorid", "menth" }));
        }
    }
}
