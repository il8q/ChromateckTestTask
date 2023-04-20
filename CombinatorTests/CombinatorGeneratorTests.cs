using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CombinatorGenerator;

namespace CombinatorTests
{
    [TestClass]
    public class CombinatorGeneratorTests
    {
        static bool checkResult(List<string> result)
        {

            foreach (string element in result)
            {
                List<string> combination = result.FindAll(current => current == element);
                Assert.IsFalse(
                    combination.Count > 1,
                    String.Format("комбинация {0} уже существует. Комбинации {1}",
                        element,
                        String.Join(", ", combination.ToArray())
                    )
                );
            }
            return true;
        }

        private void TestOnString(string source, int combinationCount)
        {
            List<string> result = new List<string>();
            CombinationGenerator combinationGenerator = CombinatorTests.CombinatorBuilderDirector.createTestCombinator(source);
            do
            {
                result.Add(combinationGenerator.generateUniqueString());
            }
            while (!combinationGenerator.printAllCombinations());

            Assert.AreEqual(result.Count, combinationCount);
            Assert.IsTrue(checkResult(result));
        }

        [TestMethod]
        public void TestFourCharString()
        {
            TestOnString("1234", 24);
            TestOnString("1134", 12);
            TestOnString("3411", 12);
            TestOnString("3114", 12);
            TestOnString("1341", 12);
            TestOnString("1114", 4);
            TestOnString("1122", 6);
        }

        private void checkSeedForString(String source, List<int> expectedSeed)
        {

            List<string> result = new List<string>();
            CombinationGenerator combinationGenerator = CombinatorTests.CombinatorBuilderDirector.createTestCombinator(source);

            int index = 0;
            do
            {
                result.Add(combinationGenerator.generateUniqueString());
                Assert.AreEqual(combinationGenerator.currentCombinationNumber, expectedSeed[index]);
                index++;
            }
            while (!combinationGenerator.printAllCombinations());
        }

        [TestMethod]
        public void TestByStepFourCharString()
        {
            this.checkSeedForString("1134", new List<int>{
                1,
                2,
                3,
                4,
                5,
                12,
                16,
                17,
                18,
                22,
                23,
                24,
            });
            this.checkSeedForString("3411", new List<int>{
                4,
                5,
                6,
                10,
                11,
                12,
                13,
                14,
                15,
                16,
                17,
                24,
            });
        }
    }
}
