using Moq;
using NUnit.Framework;

using Dealership.Contracts;
using Dealership.Engine;
using Dealership.Factories;
using System;
using System.Collections.Generic;

namespace Dealership.Tests
{
    [TestFixture]
    public class DealershipEngineTests
    {
        [Test]
        public void CreateInstance_ShouldPassCorrectly_WhenAllParametersAreValid()
        {
            var mockedInputOutputProvider = new Mock<IInputOutputProvider>();
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedCommandProvider = new Mock<ICommandProvider>();

            var dealershipEngine = new DealershipEngine(mockedFactory.Object, mockedInputOutputProvider.Object, mockedCommandProvider.Object);

            Assert.IsInstanceOf<IDealershipEngine>(dealershipEngine);
        }

        [Test]
        public void CreateInstanceShouldThrowArgumentNullException_WhenParameterInputOutputProviderIsNull()
        {
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedCommandProvider = new Mock<ICommandProvider>();

            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(mockedFactory.Object, null, mockedCommandProvider.Object));
        }

        [Test]
        public void CreateInstanceShouldThrowArgumentNullException_WhenParameterCommandProviderIsNull()
        {
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedInputOutputProvider = new Mock<IInputOutputProvider>();

            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(mockedFactory.Object,mockedInputOutputProvider.Object, null));
        }

        [Test]
        public void CreateInstanceShouldThrowArgumentNullException_WhenParameterFactoryIsNull()
        {
            var mockedCommandProvider = new Mock<ICommandProvider>();
            var mockedInputOutputProvider = new Mock<IInputOutputProvider>();

            Assert.Throws<ArgumentNullException>(() => new DealershipEngine(null, mockedInputOutputProvider.Object, mockedCommandProvider.Object));
        }

        [Test]
        public void CreateInstanceShouldSetUsersPropertyAsEmptyListOfUsers()
        {
            var mockedInputOutputProvider = new Mock<IInputOutputProvider>();
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedCommandProvider = new Mock<ICommandProvider>();

            var dealershipEngine = new DealershipEngine(mockedFactory.Object, mockedInputOutputProvider.Object, mockedCommandProvider.Object);

            Assert.AreEqual(new List<IUser>(), dealershipEngine.Users);
        }

        [Test]
        public void CreateInstanceShouldLoggedUserPropertyAsNull()
        {
            var mockedInputOutputProvider = new Mock<IInputOutputProvider>();
            var mockedFactory = new Mock<IDealershipFactory>();
            var mockedCommandProvider = new Mock<ICommandProvider>();

            var dealershipEngine = new DealershipEngine(mockedFactory.Object, mockedInputOutputProvider.Object, mockedCommandProvider.Object);

            Assert.AreEqual(null, dealershipEngine.LoggedUser);
        }
    }
}
