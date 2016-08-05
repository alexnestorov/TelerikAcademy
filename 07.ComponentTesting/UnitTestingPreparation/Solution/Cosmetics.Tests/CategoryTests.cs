using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cosmetics.Common;
using Cosmetics.Products;
using Cosmetics.Contracts;
using System.Collections.Generic;
using Moq;

namespace Cosmetics.Tests
{
    [TestClass]
    public class CategoryTests
    {
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CreatingCategoryName_WithInvalidLength_ShouldThrowAnException()
        {
            var category = new Category("ForMaleForMaleFor");


            //var errorMessage = "Category name must be between 2 and 15 symbols long!";

            //Assert.AreEqual(errorMessage,)
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreatingCategory_WithEmptyName_ShouldThrowAnException()
        {
            var category = new Category("");
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void CreatingCategory_WithNullableName_ShouldThrowAnException()
        {
            var category = new Category(null);
        }

        [TestMethod]
        public void AddingFirstProduct_MustReturnOneProductInProductsList()
        {
            var mockedCategory = new Mock<ICategory>();
            var mockedProduct = new Mock<IProduct>();

            mockedCategory.Object.AddCosmetics(mockedProduct.Object);

            mockedCategory.Verify(x => x.AddCosmetics(mockedProduct.Object), Times.Once); 
        }
    }
}
