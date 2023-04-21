using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CombinatorTests
{
    [TestClass]
    public class CombinationBuilderDirectorTests
    {
        /**
         * maxCombinationCount = !(source.Length)
         */
        private void TestForString(string source, int maxCombinationCount)
        {
            CombinatorGenerator.CombinationGenerator combinator = CombinatorBuilderDirector.createTestCombinator(
                source
            );

            Assert.AreEqual(combinator.sourceString, source);
            Assert.AreEqual(combinator.sourseStringLength, source.Length);

            Assert.AreEqual(combinator.maxCombinationMumber, maxCombinationCount);
        }

        [TestMethod]
        public void TestGenerateForWithoutDublicate()
        {
            TestForString("1234", 24);
            TestForString("1134", 24);
            TestForString("4311", 24);
            TestForString("4113", 24);
            TestForString("1341", 24);
            TestForString("1122", 24);
            TestForString("11123", 120);
        }
    }
}
