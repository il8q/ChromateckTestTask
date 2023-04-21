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

        public void СreateEmptyCombinator()
        {
            this.result = new CombinationGenerator();
        }

        public void SetStringData(string sourseString)
        {
            this.result.sourceString = sourseString;
            this.result.sourseStringLength = sourseString.Length;

            this.result.maxCombinationMumber = FactorialGenerator.generate(this.result.sourseStringLength);
            this.result.combinationCountForFirstChar = FactorialGenerator.generate(this.result.sourseStringLength - 1);

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

        internal void FindNotUniqueChars()
        {
            Dictionary<char, int> notUniqueChars = new Dictionary<char, int>();
            string sourceCharIndexes = this.result.sourceString;
            foreach (char current in sourceCharIndexes)
            {
                int count = sourceCharIndexes.Count(element => element == current);
                if ((count > 1) && !notUniqueChars.ContainsKey(current))
                {
                    notUniqueChars.Add(current, count);
                }
            }
            this.result.notUniqueChars = notUniqueChars;
        }
        
        public void FindIgnoreIndexChars()
        {
            for (int index = 0; index < this.result.sourseStringLength; index++)
            {
                if (this.result.ignoreIndexChars.Contains(index))
                {
                    continue;
                }
                List<int> findIndexes = this.FindIndexes(index, this.result.sourceString);
                findIndexes.RemoveAt(0);
                this.result.ignoreIndexChars.AddRange(findIndexes);
            }
        }
        private List<int> FindIndexes(int charIndex, string sourceCharIndexes)
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
    }
}
