using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CombinatorGenerator;

namespace CombinatorTests
{
    [TestClass]
    public class CombinationBuilderDirectorTests
    {
        private void testForString(String source, int maxCombinationCount)
        {
            CombinationGenerator combinator = CombinatorTests.CombinatorBuilderDirector.createTestCombinator(
                source
            );

            Assert.AreEqual(combinator.sourceString, source);
            Assert.AreEqual(combinator.sourseStringLength, source.Length);

            List<int> expectedIndexList = new List<int>();
            for (int i = 0; i < combinator.sourceString.Length; i++)
            {
                expectedIndexList.Add(i);
            }

            for (int i = 0; i < expectedIndexList.Count; i++)
            {
                Assert.AreEqual(combinator.indexList[i], expectedIndexList[i]);
            }

            //Assert.AreEqual(combinator.maxCombinationMumber, maxCombinationCount);
        }

        [TestMethod]
        public void testGenerateForWithoutDublicate()
        {
            testForString("1234", 24);
            testForString("1134", 12);
        }
    }
}
