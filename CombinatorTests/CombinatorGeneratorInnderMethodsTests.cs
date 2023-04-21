using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CombinatorTests
{
    [TestClass]
    public class CombinatorGeneratorInnderMethodsTests
    {
        private CombinatorGenerator.CombinationGenerator combinator;

        private void CheckResultForCurrentCombinationNumber(int currentCombinationNumber, string expected)
        {
            string result = combinator.GenerateSequenceWithoutFirstChar(
                currentCombinationNumber / expected.Length,
                0
            );
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestGenerateSequenceWithoutFirstChar()
        {
            this.combinator = CombinatorBuilderDirector.createTestCombinator(
                "1234"
            );

            Dictionary<int, string> expected = new Dictionary<int, string>();
            expected.Add(0, "123");
            expected.Add(3, "342");
            expected.Add(4, "423");

            expected.Add(6, "134");
            expected.Add(9, "341");
            expected.Add(10, "314");

            expected.Add(17, "123");
            expected.Add(19, "231");
            expected.Add(20, "312");
            expected.Add(23, "321");

            foreach (KeyValuePair<int, string> pair in expected)
            {
                this.CheckResultForCurrentCombinationNumber(pair.Key, pair.Value);
            }
        }
    }
}
