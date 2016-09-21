using System;
using NUnit.Framework;
using Matrices;

namespace TestMatrices
{
    [TestFixture]
    public class MatrixTest
    {
        [Test]
        public void MatrixUtils_ShouldBeSetUpCorrectly()
        {
            var testMatrix = new MatrixUtils(5);

            Assert.IsInstanceOf<MatrixUtils>(testMatrix);
        }

        [Test]
        public void MatrixUtilsInstance_WhenDependencyIsIncorrect_ShouldThrowProperException()
        {
            var testMatrix = new MatrixUtils(-2);

            Assert.Throws<ArgumentOutOfRangeException>(()=> new MatrixUtils(-2));
        }

        [Test]
        public void Instance_ShouldSetPropertyDimensionCounterToOne()
        {
            var testMatrix = new MatrixUtils(10);

            Assert.AreEqual(1, testMatrix.DimensionCounter);
        }

        [Test]
        public void PrintMethod_ShouldReturnString_WhenInstanceIsSetCorrectly()
        {
            var testMatrix = new MatrixUtils(4);
            var expectedResult = @"    1    0    0    0
    0    2    0    0
    0    0    3    0
    0    0    0    0";
            Assert.AreNotEqual(expectedResult, testMatrix.Print());
        }

        [Test]
        public void FindCell_ShouldReturnEmptyCell()
        {
            var testMatrix = new MatrixUtils(5);

            int result = testMatrix.FindCell(0, 0);

            Assert.AreEqual(0, result);
        }
    }
}
