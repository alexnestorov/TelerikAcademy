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
    public class TeacherAddMarkCommandTests
    {
        [Test]
        public void Constructor_ShouldPassCorrectly_WhenAllParametersAreSetUp()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedMarkFactory = new Mock<IMarkFactory>();

            Assert.IsInstanceOf<ICommand>(new TeacherAddMarkCommand(mockedEngine.Object, mockedFactory.Object,mockedMarkFactory.Object));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenEngineParameterIsNotSetUp()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();

            Assert.Throws<ArgumentNullException>(() => new TeacherAddMarkCommand(null, mockedFactory.Object, null));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenFactoryParameterIsNotSetUp()
        {
            var mockedEngine = new Mock<IEngine>();

            Assert.Throws<ArgumentNullException>(() => new TeacherAddMarkCommand(mockedEngine.Object, null, null));
        }

        [Test]
        public void Constructor_ShouldThrowArgumentNullException_WhenMarkFactoryParameterIsNotSetUp()
        {
            var mockedMarkFactory = new Mock<IMarkFactory>();

            Assert.Throws<ArgumentNullException>(() => new TeacherAddMarkCommand(null,null,mockedMarkFactory.Object));
        }

        [Test]
        public void ExecuteMethod_ShouldReturnSuccessfulMessage_WhenAddingMarksIsOK()
        {
            var mockedFactory = new Mock<ISchoolSystemFactory>();
            var mockedEngine = new Mock<IEngine>();
            var mockedMarkFactory = new Mock<IMarkFactory>();

            var addMark = new TeacherAddMarkCommand(mockedEngine.Object, mockedFactory.Object, mockedMarkFactory.Object);

            var mockedCreateStudent = new Mock<CreateStudentCommand>();
            var studentParams = "Ivan Ivanov 2".Split(' ').ToList();
            mockedCreateStudent.Object.Execute(studentParams);
            var mockedCreateTeacher = new Mock<CreateTeacherCommand>();
            var teacherParams = "Georgi Georgiev 1".Split(' ').ToList();
            mockedCreateTeacher.Object.Execute(teacherParams);

            var addMarkParams = "1 1 5".Split(' ').ToList();

            var expectedResult = "Teacher Georgi Georgiev added mark 5 to student Ivan Ivanov in English.";
            Assert.AreEqual(expectedResult, addMark.Execute(addMarkParams));
        }
    }
}
