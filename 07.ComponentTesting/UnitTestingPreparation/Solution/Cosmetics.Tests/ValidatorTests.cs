using Cosmetics.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class ValidatorTests
    {
        [TestCase(null)]
        [TestCase("")]
        public void WhenStringIsNullOrEmpty_ShouldThrowNullReferenceException(string obj)
        {
            Assert.Throws<NullReferenceException>(() => Validator.CheckIfStringIsNullOrEmpty(obj));
        }

        [TestCase(25, 25)]
        [TestCase(16, 25)]
        [TestCase(12, 5)]
        [TestCase(15, 0)]
        public void CheckIfStringLengthIsValid_WhenTextParamHasInvalidLenght_ShouldThrowIndexOutOfRangeException(int maxLength, int minLength)
        {
            var exampleString = "ParameterWithMoreThan20Symbols";

            Assert.Throws<IndexOutOfRangeException>(() => Validator.CheckIfStringLengthIsValid(exampleString, maxLength, minLength));
        }
    }
}
