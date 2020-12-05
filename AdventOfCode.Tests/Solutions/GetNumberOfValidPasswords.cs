using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode.Tests.Solutions
{
    public class GetNumberOfValidPasswordsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> GetPasswordTests
        {
            get
            {
                yield return new TestCaseData(
                        arg: new string[] {"1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc"})
                    .SetName("Example")
                    .Returns(1);
                yield return new TestCaseData(
                        arg: new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc", "2-9 c: ccccccccc" })
                    .SetName("Duplicate")
                    .Returns(1);
            }
        }

        [Test, TestCaseSource(nameof(GetPasswordTests))]
        public int GetNumberOfValidPasswordsWithoutPosition(string[] list)
        {
            return Methods.GetNumberOfValidPasswords(list, false);
        }


        private static IEnumerable<TestCaseData> GetPasswordTests2
        {
            get
            {
                yield return new TestCaseData(
                        arg: new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" })
                    .SetName("Example")
                    .Returns(1);
                yield return new TestCaseData(
                        arg: new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc", "2-9 c: ccccccccc" })
                    .SetName("Duplicate")
                    .Returns(2);
            }
        }

        [Test, TestCaseSource(nameof(GetPasswordTests2))]
        public int GetNumberOfValidPasswordsWithPosition(string[] list)
        {
            return Methods.GetNumberOfValidPasswords(list, true);
        }
    }
}