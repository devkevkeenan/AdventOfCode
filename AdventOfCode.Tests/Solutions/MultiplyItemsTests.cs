using NUnit.Framework;

namespace AdventOfCode.Tests.Solutions
{
    public class MultiplyItemsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new [] { 2, 3 }, ExpectedResult = 6)]
        [TestCase(new[] { 2, 3, 4 }, ExpectedResult = 24)]
        [TestCase(new[] { 2, 2, 2 }, ExpectedResult = 8)]
        [TestCase(new[] { 10, 10, 20 }, ExpectedResult = 2000)]
        [TestCase(new[] { -2, 3 }, ExpectedResult = -6)]
        public int MultiplyItems(int[] list)
        {
            return Methods.MultiplyItems(list);
        }
    }
}