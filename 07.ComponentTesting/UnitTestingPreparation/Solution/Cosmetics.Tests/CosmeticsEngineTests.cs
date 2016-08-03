using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Cosmetics.Engine;
using Cosmetics.Contracts;
using System.IO;
using Cosmetics.Products;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CosmeticsEngineTests
    {
        [Test]
        public void CreatingCosmeticsEngine_ShouldPassedCorrectly()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingcart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            IEngine cosmeticsEngine = new CosmeticsEngine(mockedFactory.Object, mockedShoppingcart.Object, mockedCommandParser.Object);

            Assert.IsInstanceOf<IEngine>(cosmeticsEngine);
        }

        [Test]
        public void CreatingCosmeticsEngine1_ShouldPassedCorrectly()
        {
            var mockedFactory = new Mock<ICosmeticsFactory>();
            var mockedShoppingcart = new Mock<IShoppingCart>();
            var mockedCommandParser = new Mock<ICommandParser>();

            var cosmeticsEngine = new MockedCosmeticsEngine(mockedFactory.Object, mockedShoppingcart.Object, mockedCommandParser.Object);


            var cmd1 = Command.Parse("CreateCategory ForMale");
            var cmd2 = Command.Parse("CreateCategory ForFemale");
            var cmd3 = Command.Parse("CreateShampoo Cool Nivea 0.50 men 500 everyday");
            var cmd4 = Command.Parse("AddToCategory ForMale Cool");

            var commands = new List<ICommand>()
            {
                cmd1,
                cmd2, 
                cmd3,
                cmd4
            };

//            CreateShampoo Cool Nivea 0.50 men 500 everyday
//CreateToothpaste White + Colgate 15.50 men fluor, bqla, golqma
//AddToCategory ForMale Cool

            mockedCommandParser.Setup(x => x.ReadCommands()).Returns(commands);

            var category = new Category("ForMale");
            var category1 = new Category("ForFemale");

            mockedFactory.Setup(x => x.CreateCategory(It.IsAny<string>()))
                .Returns((string param) => param.Contains("Female") ?
                                          category1 :
                                          category);


            cosmeticsEngine.Start();

            Assert.AreEqual(1, cosmeticsEngine.Products.Count);
        }

    }
}
