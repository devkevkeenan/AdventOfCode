using NUnit.Framework;

namespace AdventOfCode.Tests.MethodTests
{
    public class GetSeatTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("BFFFBBFRRR", ExpectedResult = 567)]
        [TestCase("FFFBBBFRRR", ExpectedResult = 119)]
        [TestCase("BBFFBBFRLL", ExpectedResult = 820)]
        public long GetSeat(string id)
        {
            return Methods.GetSeat(id);
        }
    }
}