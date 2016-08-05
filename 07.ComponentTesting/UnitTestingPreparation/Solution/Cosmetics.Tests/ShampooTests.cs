using Cosmetics.Common;
using Cosmetics.Products;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Tests
{
    [TestFixture]
    public class ShampooTests
    {
        [Test]
        public void ToString_ShouldReturnCorrectFormatInformation()
        {
            var expectedFormatToString = @"- Nivea - Cool:
  * Price: $125000
  * For gender: Men
  * Quantity: 500 ml
  * Usage: EveryDay";
            Product shampoo = new Shampoo("Cool", "Nivea", 250M, GenderType.Men, 500, UsageType.EveryDay);
            string output = shampoo.Print();
            Assert.AreEqual(expectedFormatToString, output);
        }                                              
    }                                                  
}
