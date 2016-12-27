using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Clusterizer;
using System.Collections;

namespace Tests
{
    [TestFixture]
    public class FingerPrintTest
    {
        [Test, TestCaseSource(nameof(TestCases))]
        public bool ShouldCompareStrings(string s1, string s2)
        {
            FingerPrint fPrint = new FingerPrint();
            return fPrint.IsTheSame(s1, s2);
        }
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("hello", "hello").Returns(true);
                yield return new TestCaseData("morning", "MornIng").Returns(true);
                yield return new TestCaseData("pay.", "pay").Returns(true);
                yield return new TestCaseData("hear", "he ar").Returns(true);
                yield return new TestCaseData("monday", "moday").Returns(false);
            }
        }
    }
}
