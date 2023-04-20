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
            //TestOnString("1234", 24);
            TestOnString("1134", 12);
            TestOnString("3411", 12);
            TestOnString("1114", 4);
            TestOnString("1122", 6);
            /**
             * 1122
             * 1221
             * 1212
             * 2211
             * 2121
             * 2112
             * 
             * 1212
             * 1221
             * 2121
             * 2211
             */
        }

        [TestMethod]
        public void TestByStepFourCharString()
        {
            const String source = "1134";
            List<string> expectedResultString = new List<string>
            {
                "1134",
                "1143",
                "1314",
                "1341",
                "1413",
                "1431",
                "3114",
                "3141",
                "3411",
                "4113",
                "4131",
                "4311",
            }; 
            List<int> expectedSeed = new List<int>
            {
                1,
                2,
                3,
                4,
                5,
                6,
                16,
                17,
                18,
                22,
                23,
                24,
            };

            List<string> result = new List<string>();
            CombinationGenerator combinationGenerator = CombinatorTests.CombinatorBuilderDirector.createTestCombinator(source);

            int index = 0;
            do
            {
                result.Add(combinationGenerator.generateUniqueString());
                Assert.AreEqual(combinationGenerator.currentCombinationNumber, expectedSeed[index]);
                //Assert.AreEqual(result[index], expectedResultString[index]);
                index++;
            }
            while (!combinationGenerator.printAllCombinations());
        }
    }
}
