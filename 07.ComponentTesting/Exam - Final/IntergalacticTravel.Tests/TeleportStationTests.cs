using IntergalacticTravel.Contracts;
using IntergalacticTravel.Exceptions;
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
    public class TeleportStationTests
    {
        [Test]
        public void TeleportStation_WhenIsCalled_ShouldSetAllProperties()
        {
            // Arrange.
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            // Act.
            var teleportStation = new MockedTeleportStation(
                mockedOwner.Object,
                mockedGalacticMap.Object,
                mockedLocation.Object);

            // Assert.
            Assert.IsNotNull(teleportStation.Location);
            Assert.IsNotNull(teleportStation.Owner);
            Assert.IsNotNull(teleportStation.GalacticMap);
            Assert.IsNotNull(teleportStation.Resources);
        }

        [Test]
        public void TeleportUnit_WhenUnitToTeleportIsNull_ShouldThrowArgumentNullException()
        {
            //IUnit unitToTeleport, ILocation targetLocation
            // Arrange.
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            var mockedTargetLocation = new Mock<ILocation>();

            // Act.
            var teleportStation = new TeleportStation(
                mockedOwner.Object,
                mockedGalacticMap.Object,
                mockedLocation.Object);

            Assert.That(() => teleportStation.TeleportUnit(null, mockedTargetLocation.Object), Throws.ArgumentNullException.With.Message.Contains("unitToTeleport"));
        }

        [Test]
        public void TeleportUnit_WhenDestinationIsNull_ShouldThrowArgumentNullException()
        {
            // Arrange.
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            var mockedUnitToTeleport = new Mock<IUnit>();

            // Act.
            var teleportStation = new TeleportStation(
                mockedOwner.Object,
                mockedGalacticMap.Object,
                mockedLocation.Object);

            // Assert.
            Assert.That(
                () => teleportStation.TeleportUnit(mockedUnitToTeleport.Object,null), Throws.ArgumentNullException.With.Message.Contains("destination"));
        }

        [Test]
        public void TeleportUnit_WhenUnitIsTryingToTeleportToDistantLocation_ShouldThrowTeleportOutOfRangeException()
        {
            // Arrange.
            var mockedOwner = new Mock<IBusinessOwner>();
            var mockedGalacticMap = new Mock<IEnumerable<IPath>>();
            var mockedLocation = new Mock<ILocation>();

            var mockedUnitToTeleport = new Mock<IUnit>();
            var mockedTargetLocation = new Mock<ILocation>();

            var teleportStation = new TeleportStation(
                            mockedOwner.Object,
                            mockedGalacticMap.Object,
                            mockedLocation.Object);

            mockedLocation.Setup(x => x.Planet.Name).Returns("Mars");
            mockedUnitToTeleport.Setup(x => x.CurrentLocation.Planet.Name).Returns("Mars");


           
            // Assert.
            Assert.That(() => teleportStation.TeleportUnit(mockedUnitToTeleport.Object, mockedTargetLocation.Object)
            , Throws.TypeOf(typeof(TeleportOutOfRangeException)).With.Message.Contains("unitToTeleport.CurrentLocation"));

        }
    }
}
