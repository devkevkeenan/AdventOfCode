using NUnit.Framework;

namespace AdventOfCode.Tests.MethodTests
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
        [TestCase(new [] { 86, 187, 75, 89, 44 }, ExpectedResult = 4723283400)]
        public long MultiplyItems(int[] list)
        {
            return Methods.MultiplyItems(list);
        }
    }
}