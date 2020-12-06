using NUnit.Framework;

namespace AdventOfCode.Tests.MethodTests
{
    public class GetItemsWhichSumToTargetTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase(new[] { 2, 3 }, 5, 2, ExpectedResult = new[] { 2, 3 })]
        [TestCase(new[] { 10, 8, 6, 4, 2, 1, 3, 5, 7, 9, 11 }, 21, 2, ExpectedResult = new[] { 10, 11 })]
        [TestCase(new[] { 10, 8, 6, 4, 2, 1, 3, 5, 7, 9, 11 }, 20, 2, ExpectedResult = new[] { 9, 11 })]
        [TestCase(new[] { 2, 3, 4 }, 9, 3, ExpectedResult = new[] { 2, 3, 4 })]
        [TestCase(new[] { 1, 1, 1, 1, 1 }, 5, 5, ExpectedResult = new[] { 1, 1, 1, 1, 1 })]
        [TestCase(new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 10 }, 17, 3, ExpectedResult = new[] { 1, 6, 10 })]
        public int[] GetItemsWhichSumToTarget(int[] list, int target, int numberOfItems)
        {
            return AdventOfCode.Methods.GetItemsWhichSumToTarget(list, target, numberOfItems);
        }
    }
}