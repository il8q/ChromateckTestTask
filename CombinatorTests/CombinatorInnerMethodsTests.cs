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
            Assert.AreEqual(combinator.findMaxIndex(), 3);
        }

        [TestMethod]
        public void testFindPremaxIndex()
        {
            Assert.AreEqual(
                combinator.findPremaxIndex(combinator.findMaxIndex()),
                2
            );
        }

        [TestMethod]
        public void testSortRemainIndexSequence()
        {
            List<int> expected = new List<int>();
            expected.Add(1);
            expected.Add(2);
            expected.Add(4);
            expected.Add(3);

            Assert.AreEqual(
                combinator.sortRemainIndexSequence(combinator.findMaxIndex()),
                expected
            );
        }
    }
}
