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
    public class RemoveStudentCommandTests
    {
        [Test]
        public void Constructor_ShouldPassCorrectly_WhenAllParametersAreSetUp()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();


            Assert.IsInstanceOf<ICommand>(new RemoveStudentCommand(mockedEngine.Object, mockedFactory.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenEngineParameterIsNotSetUp()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();

            Assert.Throws<ArgumentNullException>(() => new RemoveStudentCommand(null, mockedFactory.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFactoryParameterIsNotSetUp()
        {
            var mockedEngine = new Mock<IEngine>();

            Assert.Throws<ArgumentNullException>(() => new RemoveStudentCommand(mockedEngine.Object, null));
        }

        [Test]
        public void ExecuteMethod_ShouldReturnSuccessfullMessage_WhenStudentIsRemoved()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedCreateStudent = new Mock<CreateStudentCommand>();

            var commandString = "Ivan Ivanov 2";
            var parameters = commandString.Split(' ').ToList();
            mockedCreateStudent.Object.Execute(parameters);

            var removeStudentCommand = new RemoveStudentCommand(mockedEngine.Object, mockedFactory.Object);

            var paramsToDelete = "0".Split(' ').ToList();

            var expectedResult = "Student with ID 0 was sucessfully removed.";

            Assert.AreEqual(expectedResult, removeStudentCommand.Execute(paramsToDelete));
        }


        [Test]
        public void ExecuteMethod_ShouldThrowArgumentOutOfRangeException_WhenStudentIsNotANumber()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedCreateStudent = new Mock<CreateStudentCommand>();

            var commandString = "Ivan Ivanov 2";
            var parameters = commandString.Split(' ').ToList();
            mockedCreateStudent.Object.Execute(parameters);

            var removeStudentCommand = new RemoveStudentCommand(mockedEngine.Object, mockedFactory.Object);

            var paramsToDelete = "Neshto".Split(' ').ToList();

            Assert.Throws<ArgumentOutOfRangeException>(()=> removeStudentCommand.Execute(paramsToDelete));
        }

        [Test]
        public void ExecuteMethod_ShouldThrowProperException_WhenStudentIsNotInDb()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedCreateStudent = new Mock<CreateStudentCommand>();

            var commandString = "Ivan Ivanov 2";
            var parameters = commandString.Split(' ').ToList();
            mockedCreateStudent.Object.Execute(parameters);

            var removeStudentCommand = new RemoveStudentCommand(mockedEngine.Object, mockedFactory.Object);

            var paramsToDelete = "5".Split(' ').ToList();

            Assert.Throws<ArgumentOutOfRangeException>(() => removeStudentCommand.Execute(paramsToDelete));
        }
    }
}
