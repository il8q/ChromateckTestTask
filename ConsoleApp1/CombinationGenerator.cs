using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CombinationGenerator
    {
        private List<char> charIndexes = new List<char>();
        private List<char> sourceCharIndexes = new List<char>();
        private int currentCombinationNumber = 0;
        private int sourseStringLength;
        private int maxCombinationMumber = 0;

        public CombinationGenerator(string sourseString)
        {
            int startIndex = 0;
            int variantsCount = 0;
            foreach (char current in sourseString)
            {
                if (!this.charIndexes.Contains(current))
                {
                    variantsCount++;
                }
                this.charIndexes.Add(current);
                startIndex++;
            }
            this.sourceCharIndexes = this.charIndexes.ToList();
            this.sourseStringLength = startIndex;
            
            this.maxCombinationMumber = FactorialGenerator.generate(this.sourseStringLength);
            this.maxCombinationMumber = this.maxCombinationMumber / (this.sourseStringLength - variantsCount + 1);
        }

        internal string generateUniqueString()
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
                if (swapIndex >= 0)
                {
                    char tmp = this.charIndexes[0];
                    this.charIndexes[0] = this.charIndexes[swapIndex];
                    this.charIndexes[swapIndex] = tmp;
                }
            }
            return string.Format("{0}. {1}", this.currentCombinationNumber, result);
        }

        internal bool printAllCombinations()
        {
            return this.currentCombinationNumber == this.maxCombinationMumber;
        }
    }
}
