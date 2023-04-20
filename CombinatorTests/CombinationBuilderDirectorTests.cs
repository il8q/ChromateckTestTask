using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CombinatorGenerator;

namespace CombinatorTests
{
    [TestClass]
    public class CombinationBuilderDirectorTests
    {
        private void testForString(String source, int maxCombinationCount, List<int> expectedIndexList)
        {
            CombinationGenerator combinator = CombinatorTests.CombinatorBuilderDirector.createTestCombinator(
                source
            );

            Assert.AreEqual(combinator.sourceString, source);
            Assert.AreEqual(combinator.sourseStringLength, source.Length);

            CollectionAssert.AreEquivalent(combinator.indexList, expectedIndexList);
            Assert.AreEqual(combinator.maxCombinationMumber, maxCombinationCount);
        }

        [TestMethod]
        public void testGenerateForWithoutDublicate()
        {
            testForString("1234", 24, new List<int> {0, 1, 2, 3} );
            testForString("1134", 12, new List<int> {0, 0, 1, 2} );
            testForString("1122", 6, new List<int> {0, 0, 1, 1} );
            testForString("11123", 14, new List<int> {0, 0, 0, 1, 2} );
            /**
             * 1) !N/!Z
             * 
             * 
             * 1122 !N/!Z = !4/(!2*!2) = 4 3/ 2
             * 1212
             * 1221
             * 2112
             * 2121
             * 2211
             * 
             * 123 6=n=!n
             * 112 3=n=!n/!2=!3=3
             * 111 1=n=!n/!3=1
             * 
             * !5 / !3 = 5 4 3 2 / 3 2 = 20
             * 1 1123 6 
             * 1 1213 !n / !(n-z) = !4 / !2 = 4*3
             * 1 2113
             * 1 1132 * = 8
             * 
             * 1 1312
             * 1 3112
             * 1 3121
             * 1 3211
             * 
             * 21113 4 
             * 21131
             * 21311
             * 23111
             * 
             * 31112
             * 31121
             * 31211
             * 32111
             * =14
             */
        }
    }
}
