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
            //Assert.AreEqual(combinator.maxCombinationMumber, maxCombinationCount);
        }

        [TestMethod]
        public void testGenerateForWithoutDublicate()
        {
            testForString("1234", 24, new List<int> {0, 1, 2, 3} );
            testForString("1134", 12, new List<int> {0, 0, 1, 2} );
        }
    }
}
