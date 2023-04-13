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

        public string generateUniqueString()
        {
            string result = "";
            List<char> tempDict = this.charIndexes.ToList();

            for (int startIndex = 1; startIndex <= this.sourseStringLength; startIndex++)
            {
                int nextIndex = this.currentCombinationNumber % startIndex;
                if ((nextIndex + 1) > tempDict.Count)
                {
                    nextIndex = tempDict.Count - 1;
                }
                char nextChar = tempDict[nextIndex];
                tempDict.Remove(nextChar);
                result += nextChar;
            }

            this.currentCombinationNumber++;
            bool printAllCombinationForFirstChar = (this.currentCombinationNumber % (this.sourseStringLength - 1)) == 0;
            if (printAllCombinationForFirstChar && !this.printAllCombinations())
            {
                this.charIndexes = this.sourceCharIndexes.ToList();
                double var1 = Math.Round((float)(this.currentCombinationNumber / (this.sourseStringLength - 1)));
                int swapIndex = (int)((double)this.sourseStringLength - var1);
                if (swapIndex >= 0 && (this.charIndexes[0] != this.charIndexes[swapIndex]))
                {
                    char tmp = this.charIndexes[0];
                    this.charIndexes[0] = this.charIndexes[swapIndex];
                    this.charIndexes[swapIndex] = tmp;
                }
            }
            return string.Format("{0}. {1}", this.currentCombinationNumber, result);
        }

        public bool printAllCombinations()
        {
            return this.currentCombinationNumber == this.maxCombinationMumber;
        }
    }
}
