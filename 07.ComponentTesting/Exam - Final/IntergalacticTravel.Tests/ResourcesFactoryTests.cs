using IntergalacticTravel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalacticTravel.Tests
{
    [TestFixture]
    public class ResourcesFactoryTests
    {
        [TestCase("create resources gold(20) silver(30) bronze(40)")]
        [TestCase("create resources gold(20) bronze(40) silver(30)")]
        [TestCase("create resources silver(30) bronze(40) gold(20)")]
        [TestCase("create resources silver(30) gold(20) bronze(40)")]
        [TestCase("create resources bronze(40) gold(20) silver(30)")]
        [TestCase("create resources bronze(40) silver(30) gold(20)")]
        public void GetResources_WhenCommandStringIsWithValidPropertyNames_ShouldReturnInstanceOfResourcesWithValidSetOfAllProperties(string command)
        {
            // Arrange.
            var resourcesFactory = new ResourcesFactory();

            // Act.
            var resourcesInstance = resourcesFactory.GetResources(command);
            var expectedResources = new Resources(40, 30, 20);

            // Assert.
            Assert.AreEqual(expectedResources.BronzeCoins, resourcesInstance.BronzeCoins);
            Assert.AreEqual(expectedResources.SilverCoins, resourcesInstance.SilverCoins);
            Assert.AreEqual(expectedResources.GoldCoins, resourcesInstance.GoldCoins);
        }

        [Test]
        public void GetResources_WhenInputStringRepresentsInvalidCommand_ShouldThrowInvalidOperationException()
        {
            var resourcesFactory = new ResourcesFactory();
            var invalidInputString = "create resources gold(40) silver(30) ";

            Assert.Throws<InvalidOperationException>(() => resourcesFactory.GetResources(invalidInputString));
        }

        [Test]
        public void GetResources_WhenInputStringHasDuplicatePropertyNames_ShouldThrowInvalidOperationException()
        {
            var resourcesFactory = new ResourcesFactory();
            var invalidInputString = "create resources gold(40) silver(30) gold(20)";

            Assert.Throws<InvalidOperationException>(() => resourcesFactory.GetResources(invalidInputString));
           
        }

        [Test]
        public void GetResources_WhenInputStringHasNoWhiteSpacesBetweenCommands_ShouldThrowInvalidOperationException()
        {
            // Arrange.
            var resourcesFactory = new ResourcesFactory();
            var invalidInputString = "createresourcesgold(40)silver(30)gold(20)";

            // Act & Assert.
            Assert.Throws<InvalidOperationException>(() => resourcesFactory.GetResources(invalidInputString));

        }

        [Test]
        public void GetResources_WhenInputStringHasNonExistingPropertyName_ShouldThrowInvalidOperationException()
        {
            // Arrange.
            var resourcesFactory = new ResourcesFactory();
            var invalidInputString = "create resources gold(40) silver(30) bronzes(20)";

            // Act & Assert.
            // Found bug. Must fix the code.
            Assert.Throws<InvalidOperationException>(() => resourcesFactory.GetResources(invalidInputString));

        }

        [TestCase("create resources silver(190823490238d0) gold(5) bronze(-1)")]
        public void GetResources_WhenValuesInStringCantBeParsed_ShouldThrowInvalidOperationException(string input)
        {
            // Arrange.
            var resourcesFactory = new ResourcesFactory();

            // Act & Assert.
            Assert.Throws<InvalidOperationException>(() => resourcesFactory.GetResources(input));
        }

        [TestCase("create resources silver(20198321908310) gold(97853252356623523532) bronze(20)")]
        [TestCase("create resources silver(10) gold(53323252356623523532) bronze(20)")]
        public void GetResources_WhenInputStringValuesRepresentsAmountLargerThanUintMaxValue_ShouldThrowOverflowException(string input)
        {
            // Arrange
            var resourcesFactory = new ResourcesFactory();

            // Act & Assert
            Assert.Throws<OverflowException>(() => resourcesFactory.GetResources(input));

        }
    }
}
