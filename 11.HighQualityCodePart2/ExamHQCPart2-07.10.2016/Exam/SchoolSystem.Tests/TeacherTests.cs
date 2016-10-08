using ConsoleApplication3.Contracts;
using ConsoleApplication3.Enums;
using ConsoleApplication3.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Linq;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class TeacherTests
    {
        [Test]
        public void WhenCreatingNewStudent_ShouldPassCorrectly()
        {
            var teacher = new Teacher("Georgi", "Georgiev", 3);
            Assert.IsInstanceOf<Teacher>(teacher);
        }

        [Test]
        public void WhenCreatingNewTeacher_WithSubjectIdZero_ShouldReturnBulgarianSubject()
        {
            var teacher = new Teacher("Georgi", "Georgiev", 0);
            var subject = Subject.Bulgarian;
            Assert.AreEqual(subject, teacher.Subject);

        }

        [Test]
        public void WhenCreatingNewTeacher_WithSubjectIdOne_ShouldReturnEnglishSubject()
        {
            var teacher = new Teacher("Georgi", "Georgiev", 1);
            var subject = Subject.English;
            Assert.AreEqual(subject, teacher.Subject);

        }

        [Test]
        public void WhenCreatingNewTeacher_WithSubjectIdTwo_ShouldReturnMathSubject()
        {
            var teacher = new Teacher("Georgi", "Georgiev", 2);
            var subject = Subject.Math;
            Assert.AreEqual(subject, teacher.Subject);

        }

        [Test]
        public void WhenCreatingNewTeacher_WithSubjectIdThree_ShouldReturnProgrammingSubject()
        {
            var teacher = new Teacher("Georgi", "Georgiev", 3);
            var subject = Subject.Programming;
            Assert.AreEqual(subject, teacher.Subject);

        }

        [Test]
        public void WhenCreatingNewTeacher_WithInvalidMinFirstNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Teacher("G", "Georgiev", 1));
        }

        [Test]
        public void WhenCreatingNewTeacher_WithInvalidMinLastNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Teacher("Georgi", "p", 1));
        }

        [Test]
        public void WhenCreatingNewStudent_WithInvalidMaxFirstNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Teacher("Galskdjflksdjflksdajflkjdslkfjsdlkjflksdajflksdjlkafjsdk", "Georgiev", 0));
        }

        [Test]
        public void WhenCreatingNewStudent_WithInvalidMaxLastNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Teacher("Georgi", "pasdkjfhkjdsahfkjsdhafksdjfhkasjdfhkjsadhfkjasdgjgfdsjgadsgfahasgdjgfadshgfdsgfasgdfhdsg", 0));
        }

        [Test]
        public void WhenCreatingStudent_WithLettersDifferentFromLatinAlphabet_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Teacher("Alexander", "Александров", 0));
        }

        [Test]
        public void WhenAddMarkIsCalled_ShouldAddNewMarkInStudentsMarks()
        {
            var mockedStudent = new MockStudent("Georgi", "Georgi", "Sixth");
            var mockedMark = new Mock<IMark>();

            mockedMark.SetupGet(x => x.Subject).Returns(Subject.Math);
            mockedMark.SetupGet(x => x.SubjectValue).Returns(4);
            var teacher = new Teacher("Ivan", "Ivanov", 2);

            teacher.AddMark(mockedStudent, 4);

            Assert.AreEqual(mockedMark.Object.Subject, mockedStudent.Marks.First().Subject);
            Assert.AreEqual(mockedMark.Object.SubjectValue, mockedStudent.Marks.First().SubjectValue);
        }
    }
}
