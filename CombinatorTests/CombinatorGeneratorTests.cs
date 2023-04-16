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
            CombinatorInterface combinationGenerator = CombinatorBuilderDirector.createCombinator(source);
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
            TestOnString("1114", 4);
        }
    }
}
