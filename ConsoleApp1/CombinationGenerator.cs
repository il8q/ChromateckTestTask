using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CombinationGenerator
    {
        private List<char> charIndexes;
        private List<char> sourceCharIndexes;
        private int currentCombinationNumber = 0;
        private int sourseStringLength;
        private int maxCombinationMumber = 0;

        public CombinationGenerator(string sourseString)
        {
            this.charIndexes = new List<char>();
            this.sourceCharIndexes = new List<char>();
            int startIndex = 0;
            foreach (char current in sourseString)
            {
                this.charIndexes.Add(current);
                this.sourceCharIndexes.Add(current);
                startIndex++;
            }
            this.sourseStringLength = startIndex;
            this.maxCombinationMumber = FactorialGenerator.generate(startIndex);
        }

        internal string generateUniqueString()
        {


            string result = "";// Char.ToString(this.charIndexes[0]);
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
                int swapIndex = this.sourseStringLength - this.currentCombinationNumber / (this.sourseStringLength - 1);
                char tmp = this.charIndexes[0];
                this.charIndexes[0] = this.charIndexes[swapIndex];
                this.charIndexes[swapIndex] = tmp;
            }
            return result;
        }

        internal bool printAllCombinations()
        {
            return this.currentCombinationNumber == this.maxCombinationMumber;
        }
    }
}
