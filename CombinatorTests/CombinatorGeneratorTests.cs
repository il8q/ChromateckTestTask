using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CombinatorTests
{
    [TestClass]
    public class CombinatorGeneratorTests
    {
        static bool NotContainsDublicates(List<string> result)
        {

            foreach (string element in result)
            {
                List<string> combination = result.FindAll(current => current == element);
                Assert.IsFalse(
                    combination.Count > 1,
                    string.Format("Комбинация {0} уже существует. Комбинации {1}",
                        element,
                        string.Join(", ", combination.ToArray())
                    )
                );
            }
            return true;
        }

        private void TestOnString(string source, int combinationCount)
        {
            List<string> result = new List<string>();
            CombinatorGenerator.CombinationGenerator combinationGenerator = CombinatorBuilderDirector
                .createTestCombinator(source);
            do
            {
                result.Add(combinationGenerator.GenerateUniqueString());
            }
            while (!combinationGenerator.PrintAllCombinations());

            Assert.AreEqual(result.Count, combinationCount);
            Assert.IsTrue(NotContainsDublicates(result));
        }

        [TestMethod]
        public void TestFourCharString()
        {
            List<string> result = new List<string>();
            CombinatorGenerator.CombinationGenerator combinationGenerator = CombinatorBuilderDirector
                .createTestCombinator("31122");
            combinationGenerator.charVariantsCount = 5;
            do
            {
                result.Add(combinationGenerator.GenerateUniqueString());
            }
            while (!combinationGenerator.PrintAllCombinations());

            Assert.AreEqual(result.Count, 120);
            /*            TestOnString("1234", 24);
                        TestOnString("1134", 12);
                        TestOnString("3411", 12);
                        TestOnString("3114", 12);
                        TestOnString("1341", 12);
                        TestOnString("1114", 4);
                        TestOnString("1122", 6);*/
            TestOnString("31122", 30);
            TestOnString("32211", 30);
            TestOnString("11223", 30);
            TestOnString("32211", 30);
            TestOnString("32112", 30);
            TestOnString("11234", 60);
        }

        private void СheckSeedForString(string source, List<int> expectedSeed)
        {
            List<string> result = new List<string>();
            CombinatorGenerator.CombinationGenerator combinationGenerator = CombinatorBuilderDirector
                .createTestCombinator(source);

            int index = 0;
            do
            {
                result.Add(combinationGenerator.GenerateUniqueString());
                Assert.AreEqual(combinationGenerator.currentCombinationNumber, expectedSeed[index]);
                index++;
            }
            while (!combinationGenerator.PrintAllCombinations());
        }

        [TestMethod]
        public void TestByStepForFourCharString()
        {
            this.СheckSeedForString("1134", new List<int>{
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
            this.СheckSeedForString("3411", new List<int>{
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
