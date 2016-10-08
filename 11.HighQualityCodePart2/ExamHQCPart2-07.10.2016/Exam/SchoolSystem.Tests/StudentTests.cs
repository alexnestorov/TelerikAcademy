using ConsoleApplication3;
using NUnit.Framework;
using System;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class StudentTests
    {
        [Test]
        public void WhenCreatingNewStudent_ShouldPassCorrectly()
        {
            var student = new Student("Georgi", "Georgiev", "Sixth");
            Assert.IsInstanceOf<Student>(student);
        }

        [Test]
        public void WhenCreatingNewStudent_StudentsNumberOfMarks_ShouldBeZero()
        {
            var student = new Student("Georgi", "Georgiev", "Sixth");

            Assert.AreEqual(0, student.Marks.Count);
        }

        [Test]
        public void WhenCreatingNewStudent_WithInvalidMinFirstNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Student("G", "Georgiev", "Sixth"));
        }

        [Test]
        public void WhenCreatingNewStudent_WithInvalidMinLastNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Student("Georgi", "p", "Sixth"));
        }

        [Test]
        public void WhenCreatingNewStudent_WithInvalidMaxFirstNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Student("Galskdjflksdjflksdajflkjdslkfjsdlkjflksdajflksdjlkafjsdk", "Georgiev", "Sixth"));
        }

        [Test]
        public void WhenCreatingNewStudent_WithInvalidMaxLastNameLength_ShouldThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new Student("Georgi", "pasdkjfhkjdsahfkjsdhafksdjfhkasjdfhkjsadhfkjasdgjgfdsjgadsgfahasgdjgfadshgfdsgfasgdfhdsg", "Sixth"));
        }

        [Test]
        public void WhenCreatingStudent_WithLettersDifferentFromLatinAlphabet_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => new Student("Alexander", "Александров", "Fifth"));
        }

        [Test]
        public void WhenCreatingNew_StudentMustBeSetToOne()
        {
            var student = new Student("Ivan", "Ivanov", "Seventh");

            Assert.AreEqual(1, student.Id);
        }

        [Test]
        public void PrintStudentMarks_ShouldReturnProperMessage_WhenThereAreNoMarks()
        {
            var student = new Student("Alexander", "Ivanov", "Ninth");
            var expectedMessage = "This student has no marks";
            var actualMessage = student.PrintStudentMarks();

            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}
