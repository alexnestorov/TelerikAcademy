using ConsoleApplication3;
using ConsoleApplication3.Contracts;
using ConsoleApplication3.Enums;
using NUnit.Framework;
using System;

namespace SchoolSystem.Tests
{
    [TestFixture]
    public class MarkTests
    {
        [Test]
        public void WhenCreatingNewMark_ShouldPassCorrectly()
        {
            var mark = new Mark(Subject.Bulgarian, 6);

            Assert.IsInstanceOf<IMark>(mark);
        }

        [TestCase(1)]
        [TestCase(7)]
        [TestCase(-3)]
        public void WhenCreatingNewMark_WithInvalidValue_ShouldThrowAnException(int value)
        {
            Assert.Throws<ArgumentException>(() => new Mark(Subject.Bulgarian, value));
        }
    }
}
