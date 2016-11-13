using Moq;
using NUnit.Framework;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class CreateStudentCommandTests
    {
        [Test]
        public void Constructor_ShouldPassCorrectly_WhenAllParametersAreSetUp()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();


            Assert.IsInstanceOf<ICommand>(new CreateStudentCommand(mockedEngine.Object, mockedFactory.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenEngineParameterIsNotSetUp()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();

            Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(null, mockedFactory.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFactoryParameterIsNotSetUp()
        {
            var mockedEngine = new Mock<IEngine>();

            Assert.Throws<ArgumentNullException>(() => new CreateStudentCommand(mockedEngine.Object, null));
        }

        [Test]
        public void ExecuteMethod_ShouldReturnCommandCorrectly()
        {
            var commandString = "Pesho Peshev 11";
            var parameters = commandString.Split(' ').ToList();

            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();

            var command = new CreateStudentCommand(mockedEngine.Object, mockedFactory.Object);

            var actualCommand = command.Execute(parameters);
            var expectedResult = "A new student with name Pesho Peshev, grade 11 and ID 0 was created.";

            Assert.AreEqual(expectedResult, actualCommand);
        }

        [Test]
        public void ExecuteMethod_ShouldThrowArgumentOutOfRangeException_WhenThereAreNoParameters()
        {
            string commandString = string.Empty;
            var parameters = commandString.Split(' ').ToList();

            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();

            var command = new CreateStudentCommand(mockedEngine.Object, mockedFactory.Object);

            Assert.Throws<ArgumentOutOfRangeException>(()=> command.Execute(parameters));
        }

        [Test]
        public void ExecuteMethod_ShouldThrowException_WhenThereAreIsNoGradeParameters()
        {
            string commandString = "Pesho Peshev";
            var parameters = commandString.Split(' ').ToList();

            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();

            var command = new CreateStudentCommand(mockedEngine.Object, mockedFactory.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => command.Execute(parameters));
        }
    }
}
