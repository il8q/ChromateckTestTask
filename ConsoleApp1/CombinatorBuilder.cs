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
            this.result.combinationCountForFirstChar = FactorialGenerator.generate(this.result.sourseStringLength - 1);
            //this.result.maxCombinationMumber = this.result.maxCombinationMumber 
            //    / (this.result.sourseStringLength - variantsCount + 1);

            int variantsCount = 0;
            List<char> uniqueChars = new List<char>();
            foreach (char current in sourseString)
            {
                if (!uniqueChars.Contains(current))
                {
                    uniqueChars.Add(current);
                    variantsCount++;
                }
            }
            this.result.charVariantsCount = variantsCount;
        }


        internal void findNotUniqueChars()
        {
            this.result.ingoreCombinationCounts = new Dictionary<char, int>();

            Dictionary<char, int> notUniqueChars = new Dictionary<char, int>();
            String sourceCharIndexes = this.result.sourceString;
            foreach (char current in sourceCharIndexes)
            {
                int count = sourceCharIndexes.Count(element => element == current);
                if (
                    count > 1
                    && !notUniqueChars.ContainsKey(current)
                )
                {
                    notUniqueChars.Add(current, count);
                    this.result.ingoreCombinationCounts.Add(
                        current, this.generateIngoreCombinationCount(count)
                    );
                }
            }
            this.result.notUniqueChars = notUniqueChars;
        }

        private int generateIngoreCombinationCount(int count)
        {
            int result = 0;
            /*            for (int index = 2; index <= count; index++)
                        {
                            result += FactorialGenerator.generate(this.result.sourseStringLength - 1) / count;
                            // * (this.result.sourseStringLength - 1);
                        }*/
            result += FactorialGenerator.generate(this.result.sourseStringLength - 1) / count;

            return result;
        }
        
        public void findIgnoreIndexChars()
        {
            for (int index = 0; index < this.result.sourseStringLength; index++)
            {
                if (this.result.ignoreIndexChars.Contains(index))
                {
                    continue;
                }
                List<int> findIndexes = this.findIndexes(index, this.result.sourceString);
                findIndexes.RemoveAt(0);
                this.result.ignoreIndexChars.AddRange(findIndexes);
            }
        }
        private List<int> findIndexes(int charIndex, String sourceCharIndexes)
        {
            List<int> result = new List<int>();
            for (int index = 0; index < sourceCharIndexes.Length; index++)
            {
                int findIndex = sourceCharIndexes.IndexOf(sourceCharIndexes[charIndex], index);
                if (findIndex >= 0)
                {
                    result.Add(findIndex);
                    index = findIndex;
                }
                else
                {
                    break;
                }
            }
            return result;
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
