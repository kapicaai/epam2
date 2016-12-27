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
    class LevenTest
    {
        [Test, TestCaseSource(nameof(TestCases))]
        public bool ShouldCompareStringsPos(string s1, string s2, int level)
        {
            Levenstein algo = new Levenstein(level);
            return algo.IsTheSame(s1, s2);
        }

        public static int baseLevel = 3;
        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData("hello", "hello", baseLevel).Returns(true);
                yield return new TestCaseData("morning", "MornIng", baseLevel).Returns(true);
                yield return new TestCaseData("pay.", "pay", baseLevel).Returns(true);
                yield return new TestCaseData("hear", "he ar", baseLevel).Returns(true);
                yield return new TestCaseData("monday", "moday", baseLevel).Returns(true);
            }
        }
    }
}
