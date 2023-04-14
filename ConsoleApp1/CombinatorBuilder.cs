using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CombinatorBuilder
    {
        public CombinationGenerator result;

        public void createEmptyCombinator()
        {
            this.result = new CombinationGenerator();
        }

        public void setStringData(string sourseString)
        {
            int startIndex = 0;
            int variantsCount = 0;
            foreach (char current in sourseString)
            {
                if (!this.result.charIndexes.Contains(current))
                {
                    variantsCount++;
                }
                this.result.charIndexes.Add(current);
                startIndex++;
            }
            this.result.charVariantsCount = variantsCount;
            this.result.sourceCharIndexes = this.result.charIndexes.ToList();
            this.result.sourseStringLength = startIndex;

            this.result.maxCombinationMumber = FactorialGenerator.generate(this.result.sourseStringLength);
            this.result.maxCombinationMumber = this.result.maxCombinationMumber 
                / (this.result.sourseStringLength - variantsCount + 1);
        }

        internal void findEqualChars()
        {
            List<char> notUniqueChars = new List<char>();
            List<char> sourceCharIndexes = this.result.sourceCharIndexes;
            foreach (char current in sourceCharIndexes)
            {
                if (
                    sourceCharIndexes.Count(element => element == current) > 1
                    && !notUniqueChars.Contains(current)
                )
                {
                    notUniqueChars.Add(current);
                }
            }
            this.result.notUniqueChars = notUniqueChars;

            for (int index = 0; index < this.result.sourseStringLength; index++)
            {
                if (this.result.ignoreIndexChars.Contains(index))
                {
                    continue;
                }
                List<int> findIndexes = this.findIndexes(index, this.result.sourceCharIndexes);
                findIndexes.RemoveAt(0);
                this.result.ignoreIndexChars.AddRange(findIndexes);
            }
        }

        private List<int> findIndexes(int charIndex, List<char> sourceCharIndexes)
        {
            List<int> result = new List<int>();
            for (int index = 0; index < sourceCharIndexes.Count; index++)
            {
                int findIndex = sourceCharIndexes.IndexOf(sourceCharIndexes[charIndex], index);
                if (findIndex >= 0)
                {
                    result.Add(findIndex);
                    index = findIndex;
                } else
                {
                    break;
                }
            }
            return result;
        }
    }
}
