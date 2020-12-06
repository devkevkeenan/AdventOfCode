using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode.Tests.MethodTests
{
    public class GetNumberOfValidPasswordsTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> GetPasswordTests_PositionFalse
        {
            get
            {
                yield return new TestCaseData(
                        arg: new string[] {"1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc"})
                    .Returns(2);
                yield return new TestCaseData(
                        arg: new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc", "2-9 c: ccccccccc" })
                    .Returns(3);
            }
        }

        [Test, TestCaseSource(nameof(GetPasswordTests_PositionFalse), Category = "x")]
        public int GetNumberOfValidPasswords_PositionFalse(string[] list)
        {
            return Methods.GetNumberOfValidPasswords(list, false);
        }


        private static IEnumerable<TestCaseData> GetPasswordTests_PositionTrue
        {
            get
            {
                yield return new TestCaseData(
                        arg: new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc" })
                    .Returns(1);
                yield return new TestCaseData(
                        arg: new string[] { "1-3 a: abcde", "1-3 b: cdefg", "2-9 c: ccccccccc", "2-9 c: ccccccccc" })
                    .Returns(1);
            }
        }

        [Test, TestCaseSource(nameof(GetPasswordTests_PositionTrue), Category = "y")]
        public int GetNumberOfValidPasswords_PositionTrue(string[] list)
        {
            return Methods.GetNumberOfValidPasswords(list, true);
        }
    }
}