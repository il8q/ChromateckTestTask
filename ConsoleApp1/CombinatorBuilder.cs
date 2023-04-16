using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    public class CombinatorBuilder
    {
        public CombinationGenerator result;

        public void createEmptyCombinator()
        {
            this.result = new CombinationGenerator();
        }

        public void setStringData(string sourseString)
        {
            this.result.sourceString = sourseString;
            this.result.sourseStringLength = sourseString.Length;

            this.result.maxCombinationMumber = FactorialGenerator.generate(this.result.sourseStringLength);
            //this.result.maxCombinationMumber = this.result.maxCombinationMumber 
            //    / (this.result.sourseStringLength - variantsCount + 1);
        }

        public void generateCharIndexes()
        {
            List<int> indexList = new List<int>();
            Dictionary<char, int> indexedCharList = new Dictionary<char, int>();
            int currentIndex = 0;
            int dublicateCount = 1;
            foreach (char current in this.result.sourceString)
            {
                if (indexedCharList.ContainsKey(current))
                {
                    indexList.Add(indexedCharList[current]);
                    dublicateCount++;
                } else
                {
                    indexList.Add(currentIndex);
                    indexedCharList.Add(current, currentIndex++);
                }
            }

            Dictionary<int, char> charToIndexList = new Dictionary<int, char>();
            foreach (char current in indexedCharList.Keys)
            {
                charToIndexList.Add(indexedCharList[current], current);
            }

            this.result.charToIndexList = charToIndexList;
            this.result.maxCombinationMumber = FactorialGenerator.generate(this.result.sourseStringLength)
                / FactorialGenerator.generate(dublicateCount);
            this.result.indexList = indexList;
        }
    }
}
