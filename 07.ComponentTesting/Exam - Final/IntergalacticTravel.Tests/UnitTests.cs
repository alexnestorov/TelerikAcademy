using IntergalacticTravel.Contracts;
using IntergalacticTravel.Tests.MockClasses;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void Pay_IfObjectIsNull_ShouldThrowNullReferenceException()
        {
            // Arrange.
            var unit = new Unit(90, "Liu Kang");

            // Act & Assert.
            Assert.Throws<NullReferenceException>(() => unit.Pay(null));
        }

        [Test]
        public void Pay_IfCostObjectPassed_ShouldDecreaseAmountOfResources()
        {
            var unit = new Unit(90, "Shau Khan");

            unit.Resources.BronzeCoins = 50;
            unit.Resources.SilverCoins = 100;
            unit.Resources.GoldCoins = 150;

            var mockedResources = new MockedResources(20, 30, 40);

            unit.Pay(mockedResources);

            Assert.AreEqual(30, unit.Resources.BronzeCoins);
            Assert.AreEqual(70, unit.Resources.SilverCoins);
            Assert.AreEqual(110, unit.Resources.GoldCoins);

        }

        [Test]
        public void Pay_IfPassedSuccessfully_ShouldReturnAmountOfResourcesInCostObject()
        {
            var unit = new Unit(100, "Kano");

            var mockedResources = new MockedResources(30, 50, 70);

            var resultResources = unit.Pay(mockedResources);

            Assert.AreEqual(mockedResources.BronzeCoins, resultResources.BronzeCoins);
            Assert.AreEqual(mockedResources.SilverCoins, resultResources.SilverCoins);
            Assert.AreEqual(mockedResources.GoldCoins, resultResources.GoldCoins);
        }
    }
}
