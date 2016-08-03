using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cosmetics.Common;
using Cosmetics.Products;
using Cosmetics.Contracts;
using System.Collections.Generic;

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
            var category = new Category("ForMale");
            var ingredients = new List<string>();
            IProduct product = new Toothpaste("WhiteFresh","Colgate", 3.20m, GenderType.Unisex,ingredients);

            category.AddCosmetics(product);

            Assert.AreEqual(1, category.Products.Count);

        }
    }
}
