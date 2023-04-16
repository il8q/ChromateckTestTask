using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    public class CombinationGenerator: CombinatorInterface
    {
        public String sourceString;
        public List<int> indexList;
        public int currentCombinationNumber = 0;
        public int sourseStringLength;
        public int maxCombinationMumber = 0;
        private int printCounter = 1;
        public bool printForConsole = false;

        public string generateUniqueString()
        {
            string result = "";

            if (this.printForConsole)
            {
                return string.Format("{0}. combination seed {1}. {2}", this.printCounter++, this.currentCombinationNumber++, result);
            }
            this.currentCombinationNumber++;
            return result;
        }

        public bool printAllCombinations()
        {
            return this.currentCombinationNumber >= this.maxCombinationMumber;
        }

        private void swap(ref List<int> indexArray, int i, int j)
        {
            int s = indexArray[i];
            indexArray[i] = indexArray[j];
            indexArray[j] = s;
        }

        public bool generateNextCombination(List<int> list, int sequenceLength)
        {
            int maxSwapIndex = this.findMaxIndex();
            if (maxSwapIndex < 0)
            {
                return false;
            }

            int premaxSwapIndex = this.findPremaxIndex(maxSwapIndex);
            this.sortRemainIndexSequence(maxSwapIndex);
            return true;
        }

        public int findMaxIndex()
        {
            int maxIndex = this.sourseStringLength - 2;
            while (
                maxIndex >= 0 
                && this.indexList[maxIndex] >= this.indexList[maxIndex + 1]
            )
            {
                maxIndex--;
            }
            return maxIndex;
        }

        public int findPremaxIndex(int maxSwapIndex)
        {
            int premaxSwapIndex = this.sourseStringLength - 1;
            while (this.indexList[maxSwapIndex] >= this.indexList[premaxSwapIndex])
            {
                premaxSwapIndex--;
            }
            this.swap(ref this.indexList, maxSwapIndex, premaxSwapIndex);
            return premaxSwapIndex;
        }

        public List<int> sortRemainIndexSequence(int maxSwapIndex)
        {
            int left = maxSwapIndex + 1;
            int right = this.sourseStringLength - 1;
            while (left < right)
            {
                this.swap(ref this.indexList, left++, right--);
            }
            return this.indexList;
        }
    }
}
