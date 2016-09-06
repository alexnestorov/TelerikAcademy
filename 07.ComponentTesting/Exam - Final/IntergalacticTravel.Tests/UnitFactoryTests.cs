using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class UnitFactoryTests
    {
        [TestCase("create unit Procyon Gosh 1", typeof(Procyon))]
        [TestCase("create unit Luyten Pesh 2", typeof(Luyten))]
        [TestCase("create unit Lacaille NoName 2", typeof(Lacaille))]
        public void GetUnit_WhenAValidCorrespondingCommandIsPassed_ShouldReturnProperInstanceOfClass(string name, Type expectedUnitInstance)
        {
            var unitFactory = new UnitsFactory();

            var unitInstance = unitFactory.GetUnit("create unit Procyon Gosho 1");

            Assert.IsInstanceOf(expectedUnitInstance.GetType(), unitInstance.GetType());
        }

        [Test]
        public void GetUnit_WhenCorrespondingCommandIsInvalidFormat_ShouldThrowInvalidUnitCreationCommandException()
        {
            // Arrange.
            var unitFactory = new UnitsFactory();

            // Act & Assert.
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit("create an unit Procyon Gosho 1"));

        }

        [Test]
        public void GetUnit_WhenCommandIsInvalidFormat_ShouldThrowInvalidUnitCreationCommandException()
        {
            // Arrange.
            var unitFactory = new UnitsFactory();
            var command = "createunitProcyonJamie";

            // Act & Assert.
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit(command));

        }

        [Test]
        public void GetUnit_WhenCommandStringIsEmpty_ShouldThrowInvalidUnitCreationCommandException()
        {
            // Arrange.
            var unitFactory = new UnitsFactory();
            var command = string.Empty;

            // Act & Assert.
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit(command));

        }


        [Test]
        public void GetUnit_WhenCommandHasInvalidUnitId_ShouldThrowInvalidUnitCreationCommandException()
        {
            // Arrange.
            var unitFactory = new UnitsFactory();
            var command = "create unit Procyon Darcy Oake";

            // Act & Assert.
            Assert.Throws<InvalidUnitCreationCommandException>(() => unitFactory.GetUnit(command));

        }
    }
}
