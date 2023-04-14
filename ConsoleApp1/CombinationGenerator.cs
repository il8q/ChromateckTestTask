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
        public List<char> notUniqueChars;
        public int charVariantsCount;
        private int printCounter = 1;

        public string generateUniqueString()
        {
            string result = "";
            List<char> tempDict = this.charIndexes.ToList();
            List<int> charIndexs = new List<int>();

            
            int firstCharIndex = this.changeFirstSequenceCharIndex();
            result += this.sourceCharIndexes[firstCharIndex];

            result += this.generateSequenceWithoutFirstChar(firstCharIndex);

            return string.Format("{0}. combination seed {1}. {2}", this.printCounter++, this.currentCombinationNumber++, result);
        }

        private string generateSequenceWithoutFirstChar(int firstCharIndex)
        {
            //char firstChar = this.sourceCharIndexes[firstCharIndex];
            string result = "";
            List<char> tempDict = this.charIndexes.ToList();
            tempDict.RemoveAt(firstCharIndex);
            int permutationSeed = this.currentCombinationNumber % (this.sourseStringLength - 1);

            for (int startIndex = 0; startIndex < (this.sourseStringLength - 1); startIndex++)
            {
                int nextIndex = startIndex + permutationSeed;
                if ((nextIndex + 1) > tempDict.Count)
                {
                    nextIndex = nextIndex - tempDict.Count;
                }
                char nextChar = tempDict[nextIndex];
                //tempDict.RemoveAt(nextIndex);
                result += nextChar;
            }
            return result;
        }

        private int changeFirstSequenceCharIndex()
        {
            int result = this.getCharIndex(this.currentCombinationNumber);
            while (this.ignoreIndexChars.Contains(result))
            {
                this.skipTheCharVariants();
                result = this.getCharIndex(this.currentCombinationNumber);
            }
            return result;
        }

        private void skipTheCharVariants()
        {
            this.currentCombinationNumber += this.sourseStringLength;
        }

        private int getCharIndex(int seed)
        {
            return (int)Math.Round(
                (double)(seed / (this.sourseStringLength - 1))
            );
        }

        public bool printAllCombinations()
        {
            return this.currentCombinationNumber == this.maxCombinationMumber;
        }
    }
}
