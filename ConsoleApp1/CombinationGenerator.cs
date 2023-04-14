using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CombinationGenerator: CombinatorInterface
    {
        public List<char> charIndexes = new List<char>();
        public List<char> sourceCharIndexes = new List<char>();
        public int currentCombinationNumber = 0;
        public int sourseStringLength;
        public int maxCombinationMumber = 0;
        public List<int> ignoreIndexChars = new List<int>();
        public Dictionary<char, int> notUniqueChars;
        public int charVariantsCount;
        public int combinationCountForFirstChar;
        private int printCounter = 1;
        public bool printForConsole = true;
        public Dictionary<char, int> ingoreCombinationCounts;

        public string generateUniqueString()
        {
            string result = "";
            List<char> tempDict = this.charIndexes.ToList();
            List<int> charIndexs = new List<int>();

            
            int firstCharIndex = this.changeFirstSequenceCharIndex();
            if (firstCharIndex < 0 || firstCharIndex >= this.sourseStringLength)
            {
                firstCharIndex = firstCharIndex;
            }
            result += this.sourceCharIndexes[firstCharIndex];

            result += this.generateSequenceWithoutFirstChar(firstCharIndex);

            if (this.printForConsole)
            {
                return string.Format("{0}. combination seed {1}. {2}", this.printCounter++, this.currentCombinationNumber++, result);

            }
            this.currentCombinationNumber++;
            return result;
        }

        private string generateSequenceWithoutFirstChar(int firstCharIndex)
        {
            string result = "";
            List<char> tempDict = this.charIndexes.ToList();
            tempDict.RemoveAt(firstCharIndex);
            int permutationSeed = this.currentCombinationNumber % (this.sourseStringLength - 1);
            char seedChar = this.sourceCharIndexes[permutationSeed];

            for (int startIndex = tempDict.Count; startIndex > 0; startIndex--)
            {
                int currentIndex = this.currentCombinationNumber % startIndex;
                char nextChar = tempDict[currentIndex];
                if (this.ingoreCombinationCounts.ContainsKey(nextChar)
                    && this.ingoreCombinationCounts[nextChar] > 0)
                {
                    //this.currentCombinationNumber += this.ingoreCombinationCounts[nextChar];
                }
                tempDict.RemoveAt(currentIndex);
                result += nextChar;
            }
            result.Reverse();
            return result;
        }

        private int changeFirstSequenceCharIndex()
        {
            int result = this.getCharIndex(this.currentCombinationNumber);

            while (this.ignoreIndexChars.Contains(result))
            {
                this.skipTheCharVariants(result);
                result = this.getCharIndex(this.currentCombinationNumber);
            }

            return result;
        }

        private void skipTheCharVariants(int charIndex)
        {
            char currentChar = this.sourceCharIndexes[charIndex];
            this.currentCombinationNumber += this.combinationCountForFirstChar;// * this.notUniqueChars[currentChar];
        }

        private int getCharIndex(int seed)
        {
            return (int)Math.Round(
                (double)(seed / this.combinationCountForFirstChar)//(this.sourseStringLength - 1)
            );
        }

        public bool printAllCombinations()
        {
            return this.currentCombinationNumber == this.maxCombinationMumber;
        }
    }
}
