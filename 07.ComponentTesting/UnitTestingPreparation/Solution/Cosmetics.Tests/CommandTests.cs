using Cosmetics.Engine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class CommandTests
    {
        [Test]
        public void AddingCommandName_WithValueNull_ShouldThrowProperException()
        {
            Assert.Throws<ArgumentNullException>(()=> Command.Parse(""));
        }

        [TestCase("Create Shampoo")]
        [TestCase("Create Category")]
        [TestCase("Create Toothpaste")]
        [TestCase("Create Shampoo")]
        [TestCase("Create Shampoo")]
        public void AddingCommandName_WithSplitCommandSymbol_ShouldReturnName(string input)
        {
            var command = Command.Parse(input);

            Assert.AreEqual("Create", command.Name);
        }

        [TestCase("Create   ")]
        [TestCase("Create ")]
        [TestCase("Create   ")]
        public void AddingCommandName_ContainingOneWordAndSplitCommandSymbol_ShouldThrowProperException(string input)
        {

            Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
        }

        [TestCase("Create Shampoo NiveaWashHair 500ml")]
        [TestCase("Create Shampoo WashGo 250ml")]
        [TestCase("Create Shampoo NiveaWashHair 500ml")]
        [TestCase("Create Toothpaste Aquafresh WhiteFresh")]
        [TestCase("Create Toothpaste Colgate White")]
        public void Input_ContainingFourWords_ShouldReturnThreeCommandParameters(string input)
        {
            var command = Command.Parse(input);

            Assert.AreEqual(3, command.Parameters.Count);
        }
    }
}
