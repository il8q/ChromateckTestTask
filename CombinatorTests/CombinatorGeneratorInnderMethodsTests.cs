using CombinatorGenerator;
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
                combinator.GetCharIndex(currentCombinationNumber),
                currentCombinationNumber
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

            expected.Add(0, "234");
            expected.Add(1, "243");
            expected.Add(2, "324");
            expected.Add(3, "342");
            expected.Add(4, "423");
            expected.Add(5, "432");

            expected.Add(6, "134");
            expected.Add(7, "143");
            expected.Add(8, "314");
            expected.Add(9, "341");
            expected.Add(10, "413");
            expected.Add(11, "431");

            expected.Add(12, "124");
            expected.Add(13, "142");
            expected.Add(14, "214");
            expected.Add(15, "241");
            expected.Add(16, "412");
            expected.Add(17, "421");
            
            expected.Add(18, "123");
            expected.Add(19, "132");
            expected.Add(20, "213");
            expected.Add(21, "231");
            expected.Add(22, "312");
            expected.Add(23, "321");

            foreach (KeyValuePair<int, string> pair in expected)
            {
                this.CheckResultForCurrentCombinationNumber(pair.Key, pair.Value);
            }
        }
    }
}
