using Moq;
using NUnit.Framework;
using SortingAndSearchingApp;
using System;
using System.Collections.Generic;

namespace Searching.Tests
{
    /// <summary>
    /// Summary description for SearchingTests
    /// </summary>
    [TestFixture]
    public class SearchingTests
    {
        [Test]
        public void Constructor_ShouldReturnItemsListOfTItemsWithTypeInteger_WhenTIsInteger()
        {
            var srtCollection = new SortableCollection<int>();

            Assert.AreEqual(new List<int>(), srtCollection.Items);
        }

        [Test]
        public void Constructor_ShouldReturnItemsListOfTItemsWithTypeString_WhenTIsString()
        {
            var srtCollection = new SortableCollection<string>();

            Assert.AreEqual(new List<string>(), srtCollection.Items);
        }

        [Test]
        public void Constructor_ShouldReturnItemsListOfTItemsWithTypeDecimal_WhenTIsDecimal()
        {
            var srtCollection = new SortableCollection<decimal>();

            Assert.AreEqual(new List<decimal>(), srtCollection.Items);
        }

        [Test]
        public void Constructor_ShouldReturnItemsListOfTItemsWithTypeInteger_WhenParameterIsInteger()
        {
            var items = new List<int>
            {
                1, 2, 3, 4 ,5 ,6, 7, 8
            };
            var srtCollection = new SortableCollection<int>(items);

            Assert.AreEqual(items, srtCollection.Items);
        }

        [Test]
        public void Constructor_ShouldReturnItemsListOfTItemsWithTypeString_WhenParameterIsString()
        {
            var items = new List<string>
            {
                "Mickey Mouse", "Atanas", "Spas", "Oshte kup glupavi stringove :)"
            };
            var srtCollection = new SortableCollection<string>(items);

            Assert.AreEqual(items, srtCollection.Items);
        }

        [Test]
        public void LinearSearch_ShouldReturnTrue_WhenItemExistInItems()
        {
            var items = new List<string>
            {
                "Mickey Mouse", "Atanas", "Spas", "Oshte kup glupavi stringove :)"
            };
            var srtCollection = new SortableCollection<string>(items);
            var result = srtCollection.LinearSearch("Atanas");

            Assert.IsTrue(result);
        }

        [Test]
        public void LinearSearch_ShouldReturnTrue_WhenItemExistInItemsAndIsInteger()
        {
            var items = new List<int>
            {
                1, 2, 3, 4 ,5 ,6, 7, 8
            };
            var srtCollection = new SortableCollection<int>(items);
            var result = srtCollection.LinearSearch(5);

            Assert.IsTrue(result);
        }

        [Test]
        public void LinearSearch_ShouldReturnFalse_WhenItemExistInItems()
        {
            var items = new List<string>
            {
                "Mickey Mouse", "Atanas", "Spas", "Oshte kup glupavi stringove :)"
            };
            var srtCollection = new SortableCollection<string>(items);
            var result = srtCollection.LinearSearch("Vasko");

            Assert.IsFalse(result);
        }

        public void LinearSearch_ShouldReturnFalse_WhenItemExistInItemsAndIsInteger()
        {
            var items = new List<int>
            {
                1, 2, 3, 4 ,5 ,6, 7, 8
            };
            var srtCollection = new SortableCollection<int>(items);
            var result = srtCollection.LinearSearch(15);

            Assert.IsFalse(result);
        }


        [Test]
        public void BinarySearch_ShouldReturnTrue_WhenItemExistInItems()
        {
            var items = new List<string>
            {
                "Mickey Mouse", "Atanas", "Spas", "Oshte kup glupavi stringove :)"
            };
            var srtCollection = new SortableCollection<string>(items);
            var result = srtCollection.BinarySearch("Atanas");

            Assert.IsTrue(result);
        }

        [Test]
        public void BinarySearch_ShouldReturnTrue_WhenItemExistInItemsAndIsInteger()
        {
            var items = new List<int>
            {
                1, 2, 3, 4 ,5 ,6, 7, 8
            };
            var srtCollection = new SortableCollection<int>(items);
            var result = srtCollection.BinarySearch(5);

            Assert.IsTrue(result);
        }

        [Test]
        public void BinarySearch_ShouldReturnFalse_WhenItemExistInItems()
        {
            var items = new List<string>
            {
                "Mickey Mouse", "Atanas", "Spas", "Oshte kup glupavi stringove :)"
            };
            var srtCollection = new SortableCollection<string>(items);
            var result = srtCollection.BinarySearch("Vasko");

            Assert.IsFalse(result);
        }

        [Test]
        public void BinarySearch_ShouldReturnFalse_WhenItemExistInItemsAndIsInteger()
        {
            var items = new List<int>
            {
                1, 12, 3, 4 ,5 ,6, 7, 8
            };
            var srtCollection = new SortableCollection<int>(items);
            var result = srtCollection.BinarySearch(15);

            Assert.IsFalse(result);
        }

        [Test]
        public void SortMethod_ShouldSortCollectionCorrectly_WithTypeQuickSorterOfISorterInterface()
        {

            var sorter = new Mock<Quicksorter<int>>();
            var items = new List<int>
            {
                1, 12, 3, 14 ,5 ,66, 7, 648
            };
            var srtCollection = new SortableCollection<int>(items);
            srtCollection.Sort(sorter.Object);

            Assert.AreEqual(new List<int> { 1, 3, 5, 7, 12, 14, 66, 648 }, srtCollection.Items);
        }

        [Test]
        public void SortMethod_ShouldSortCollectionCorrectly_WithTypeMergeSorterOfISorterInterface()
        {

            var sorter = new Mock<MergeSorter<int>>();
            var items = new List<int>
            {
                1, 12, 3, 14 ,5 ,66, 7, 648
            };
            var srtCollection = new SortableCollection<int>(items);
            srtCollection.Sort(sorter.Object);

            Assert.AreEqual(new List<int> { 1, 3, 5, 7, 12, 14, 66, 648 }, srtCollection.Items);
        }

        [Test]
        public void SortMethod_ShouldSortCollectionCorrectly_WithTypeSelectionSorterOfISorterInterface()
        {

            var sorter = new Mock<SelectionSorter<int>>();
            var items = new List<int>
            {
                1, 12, 3, 14 ,5 ,66, 7, 648
            };
            var srtCollection = new SortableCollection<int>(items);
            srtCollection.Sort(sorter.Object);

            Assert.AreEqual(new List<int> { 1, 3, 5, 7, 12, 14, 66, 648 }, srtCollection.Items);
        }
    }
}
