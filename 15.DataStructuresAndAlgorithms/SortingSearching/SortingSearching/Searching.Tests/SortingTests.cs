using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;
using SortingAndSearchingApp;

namespace Searching.Tests
{
    /// <summary>
    /// Summary description for SortingTests
    /// </summary>
    [TestFixture]
    public class SortingTests
    {
        [Test]
        public void MergeSorter_ShouldSortItemsCorrectly()
        {
            var collection = new List<int>()
            {
                13,1,199,2910,2
            };

            var mergeSorter = new MergeSorter<int>();

            mergeSorter.Sort(collection);

            Assert.AreEqual(new List<int>() { 1, 2, 13, 199, 2910 }, collection);
        }

        [Test]
        public void MergeSorter_ShouldTheSameCollection_WhenItemsAreExactlyOne()
        {
            var collection = new List<int>()
            {
                13
            };

            var mergeSorter = new MergeSorter<int>();

            mergeSorter.Sort(collection);

            Assert.AreEqual(new List<int>() { 13}, collection);
        }

        [Test]
        public void QuickSorter_ShouldSortItemsCorrectly()
        {
            var collection = new List<int>()
            {
                13,1,199,2910,2
            };

            var quickSorter = new Quicksorter<int>();

            quickSorter.Sort(collection);

            Assert.AreEqual(new List<int>() { 1, 2, 13, 199, 2910 }, collection);
        }

        [Test]
        public void QuickSorter_ShouldNotReturnSameCollection_WhenItemsAreNotSorted()
        {
            var collection = new List<int>()
            {
                13,1,199,2910,2
            };

            var quickSorter = new Quicksorter<int>();

            quickSorter.Sort(collection);

            Assert.AreNotEqual(new List<int>() { 13, 1, 199, 2910, 2 }, collection);
        }

        [Test]
        public void QuickSorter_ShouldTheSameCollection_WhenItemsAreExactlyOne()
        {
            var collection = new List<int>()
            {
                13
            };

            var quickSorter = new Quicksorter<int>();

            quickSorter.Sort(collection);

            Assert.AreEqual(new List<int>() { 13 }, collection);
        }

        [Test]
        public void SelectionSorter_ShouldTheSameCollection_WhenItemsAreExactlyOne()
        {
            var collection = new List<int>()
            {
                7
            };

            var selectionSorter = new Quicksorter<int>();

            selectionSorter.Sort(collection);

            Assert.AreEqual(new List<int>() { 7 }, collection);
        }

        [Test]
        public void SelectionSorter_ShouldSortCollectionCorrectly()
        {
            var collection = new List<int>()
            {
                7, 1213, 1, -1
            };

            var selectionSorter = new Quicksorter<int>();

            selectionSorter.Sort(collection);

            Assert.AreEqual(new List<int>() { -1,1,7,1213 }, collection);
        }

        [Test]
        public void SelectionSorter_ShouldSortStringCollectionCorrectly()
        {
            var collection = new List<string>()
            {
                "ivan", "atanas", "ivana", "atanaska"
            };

            var selectionSorter = new SelectionSorter<string>();

            selectionSorter.Sort(collection);

            Assert.AreEqual(new List<string>() { "atanas", "atanaska", "ivan", "ivana" }, collection);
        }

        [Test]
        public void QuickSorter_ShouldSortStringCollectionCorrectly()
        {
            var collection = new List<string>()
            {
                "ivan", "atanas", "ivana", "atanaska"
            };

            var quickSorter = new Quicksorter<string>();

            quickSorter.Sort(collection);

            Assert.AreEqual(new List<string>() { "atanas", "atanaska", "ivan", "ivana" }, collection);
        }

        [Test]
        public void MergeSorter_ShouldSortStringCollectionCorrectly()
        {
            var collection = new List<string>()
            {
                "ivan", "atanas", "ivana", "atanaska"
            };

            var mergeSorter = new MergeSorter<string>();

            mergeSorter.Sort(collection);

            Assert.AreEqual(new List<string>() { "atanas", "atanaska", "ivan", "ivana" }, collection);
        }
    }
}
