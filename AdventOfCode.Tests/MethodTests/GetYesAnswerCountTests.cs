using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCode.Tests.MethodTests
{
    public class GetYesAnswerCountTests
    {
        [SetUp]
        public void Setup()
        {
        }

        private static IEnumerable<TestCaseData> GetAnyYesAnswerCountTestData
        {
            get
            {
                yield return new TestCaseData(
                        arg: new string[] { "abc" })
                    .Returns(3);
                yield return new TestCaseData(
                        arg: new string[] { "a", "b", "c" })
                    .Returns(3);
                yield return new TestCaseData(
                        arg: new string[] { "ab", "ac" })
                    .Returns(3);
                yield return new TestCaseData(
                        arg: new string[] { "a", "a", "a", "a" })
                    .Returns(1);
                yield return new TestCaseData(
                        arg: new string[] { "a" })
                    .Returns(1);
            }
        }

        [Test, TestCaseSource(nameof(GetAnyYesAnswerCountTestData), Category = "x")]
        public int GetAnyYesAnswerCount(string[] list)
        {
            return Methods.GetAnyYesAnswerCount(list);
        }

        private static IEnumerable<TestCaseData> GetAllYesAnswerCountTestData
        {
            get
            {
                yield return new TestCaseData(
                        arg: new string[] { "abc" })
                    .Returns(3);
                yield return new TestCaseData(
                        arg: new string[] { "a", "b", "c" })
                    .Returns(0);
                yield return new TestCaseData(
                        arg: new string[] { "ab", "ac" })
                    .Returns(1);
                yield return new TestCaseData(
                        arg: new string[] { "a", "a", "a", "a" })
                    .Returns(1);
                yield return new TestCaseData(
                        arg: new string[] { "a" })
                    .Returns(1);
                yield return new TestCaseData(
                        arg: new string[] { "aa", "ab", "c" })
                    .Returns(0);
            }
        }

        [Test, TestCaseSource(nameof(GetAllYesAnswerCountTestData), Category = "x")]
        public int GetAllYesAnswerCount(string[] list)
        {
            return Methods.GetAllYesAnswerCount(list);
        }
    }
}