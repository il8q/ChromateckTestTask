using CombinatorGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CombinatorTests
{
    [TestClass]
    public class CombinatorInnerMethodsTests
    {
        CombinationGenerator combinator;

        [TestInitialize]
        public void testInitialize()
        {
            this.combinator = CombinatorTests.CombinatorBuilderDirector.createTestCombinator(
                "1234"
            );
        }


        [TestMethod]
        public void testFindMaxIndex()
        {
            Assert.AreEqual(combinator.findMaxIndex(), 2);
        }

        [TestMethod]
        public void testFindPremaxIndex()
        {
            Assert.AreEqual(
                combinator.findPremaxIndex(combinator.findMaxIndex()),
                3
            );
        }

        [TestMethod]
        public void testSortRemainIndexSequence()
        {
            List<int> expected = new List<int>();
            expected.Add(0);
            expected.Add(1);
            expected.Add(3);
            expected.Add(2);

            CollectionAssert.AreEquivalent(
                combinator.sortRemainIndexSequence(combinator.findMaxIndex()),
                expected
            );
        }

        [TestMethod]
        public void testSortRemainIndexSequence2()
        {
            CombinationGenerator combinator = CombinatorTests.CombinatorBuilderDirector.createTestCombinator(
                "1134"
            );
            combinator.indexList = new List<int> { 0, 2, 1, 0 };
            List<int> expected = new List<int> { 1, 0, 0, 2 };

            int maxIndex = combinator.findMaxIndex();
            int premaxIndex = combinator.findPremaxIndex(maxIndex);
            List<int> result = combinator.sortRemainIndexSequence(maxIndex);
            CollectionAssert.AreEqual(
                result,
                expected
            );
        }
    }
}
