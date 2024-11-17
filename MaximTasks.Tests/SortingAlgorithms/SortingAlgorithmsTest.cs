using NUnit.Framework;
using MaximTasks.SortingAlgorithms;
using System;
using System.Collections.Generic;

namespace MaximTasks.Tests.SortingAlgorithms
{
    public class SortingAlgorithmsTests
    {
        [Test]
		[TestCase("nidfhunuiehbdfguhb")]
		[TestCase("prikolveka")]
		public void QuickSort_SortsStringCorrectly(string input)
		{
			var sortedString = QuickSortClass.SortedString(input);
			Assert.That(sortedString, Is.EqualTo(string.Join("", input.OrderBy(c => c))));
		}

		[Test]
		[TestCase("nidfhunuiehbdfguhb")]
		[TestCase("prikolveka")]
		public void TreeSort_SortsStringCorrectly(string input)
		{
			var sortedString = TreeSortClass.SortedString(input);
			Assert.That(sortedString, Is.EqualTo(string.Join("", input.OrderBy(c => c))));
		}

		[Test]
		[TestCase("bbddeffghhhiinnuuu")]
		[TestCase("aeikkloprv")]
		public void QuickSort_HandlesAlreadySortedString(string input)
		{
			var sortedString = QuickSortClass.SortedString(input);
			Assert.That(sortedString, Is.EqualTo(string.Join("", input.OrderBy(c => c))));
		}

		[Test]
		[TestCase("bbddeffghhhiinnuuu")]
		[TestCase("aeikkloprv")]
		public void TreeSort_HandlesAlreadySortedString(string input)
		{
			var sortedString = TreeSortClass.SortedString(input);
			Assert.That(sortedString, Is.EqualTo(string.Join("", input.OrderBy(c => c))));
		}
    }
}
