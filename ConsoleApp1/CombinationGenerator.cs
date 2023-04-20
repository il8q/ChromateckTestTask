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
        public Dictionary<int, char> charToIndexList;
        public int currentCombinationNumber = 0;
        public int sourseStringLength;
        public int maxCombinationMumber = 0;
        private int printCounter = 1;
        public bool printForConsole = true;

        public List<int> ignoreIndexChars = new List<int>();
        public int combinationCountForFirstChar;
        public Dictionary<char, int> ingoreCombinationCounts;
        public int charVariantsCount;
        public Dictionary<char, int> notUniqueChars;

        public string generateUniqueString()
        {
            string result = "";

            int firstCharIndex = this.changeFirstSequenceCharIndex();
            result += this.sourceString[firstCharIndex];
            result += this.generateSequenceWithoutFirstChar(firstCharIndex);

            if (this.printForConsole)
            {
                result = string.Format("{0}. combination seed {1}. {2}", this.printCounter++, this.currentCombinationNumber, result);
            }
            this.currentCombinationNumber++;


            bool skipDublicateFirstChar = false;

            int nextPermutationSeed = this.getCharIndex(this.currentCombinationNumber);
            while (
                this.ignoreIndexChars.Contains(nextPermutationSeed)
                && !printAllCombinations()
                )
            {
                this.skipTheCharVariants(nextPermutationSeed);
                nextPermutationSeed = this.getCharIndex(this.currentCombinationNumber);
            }

            return result;
        }

        private int changeFirstSequenceCharIndex()
        {
            int result = this.getCharIndex(this.currentCombinationNumber);
            if (needSkipDublicates())
            {
                result = this.skipEquivalentCombinationsForFirstChar(result);
            }
            return result;
        }

        private bool needSkipDublicates()
        {
            return this.charVariantsCount < this.sourseStringLength;
        }

        private int skipEquivalentCombinationsForFirstChar(int result)
        {
            int temp = this.currentCombinationNumber;

            if (printAllCombinations())
            {
                return this.sourseStringLength - 1;
            }

            int permutationSeed = this.currentCombinationNumber % (this.maxCombinationMumber / this.sourseStringLength);
            // currentSeedOnStartCombinationSet=true - означает что мы только начинаем перебирать комбинации
            // для первого выбранного символа
            bool currentSeedOnStartCombinationSet = permutationSeed == 0;
            if (currentSeedOnStartCombinationSet)
            {
                int uniqueCombinationCount = this.getCombinationCount(this.sourseStringLength - 1, this.sourceString[result]);
                this.currentCombinationNumber += this.combinationCountForFirstChar - uniqueCombinationCount;
            }
            return result;
        }

        private bool remainLastSetForFirstChar()
        {
            bool value = this.currentCombinationNumber <
            (
                this.maxCombinationMumber /
                this.sourseStringLength * (this.sourseStringLength - 1)
            );
            return value;
        }

        private void skipTheCharVariants(int charIndex)
        {
            char currentChar = this.sourceString[charIndex];
            this.currentCombinationNumber += this.combinationCountForFirstChar;
        }

        private int getCharIndex(int seed)
        {
            return (int)Math.Ceiling(
                (double)(seed / this.combinationCountForFirstChar)
            );
        }

        private string generateSequenceWithoutFirstChar(int firstCharIndex)
        {
            string result = "";
            String tempString = this.sourceString;

            tempString = tempString.Remove(firstCharIndex, 1);//-1?
            int permutationSeed = this.currentCombinationNumber % (this.sourseStringLength - 1);
            char seedChar = this.sourceString[permutationSeed];

            for (int startIndex = tempString.Length; startIndex > 0; startIndex--)
            {
                int currentIndex = this.currentCombinationNumber % startIndex;
                char currentChar = tempString[currentIndex];

                tempString = tempString.Remove(currentIndex, 1);
                result += currentChar;
            }

            result.Reverse();
            return result;
        }

        private int getCombinationCount(int stringLength, char ignoredChar)
        {
            int denominator = 1;
            int notUniqueCharCount = 0;
            foreach (KeyValuePair<char, int> currentPair in this.notUniqueChars)
            {
                if (currentPair.Key == ignoredChar)
                {
                    denominator *= FactorialGenerator.generate(currentPair.Value - 1);
                } else
                {
                    denominator *= FactorialGenerator.generate(currentPair.Value);
                }
            }

            int combinationCount = FactorialGenerator.generate(stringLength) / denominator;
            return combinationCount;
        }

        private string generateCurrentString()
        {
            String result = "";
            foreach (int index in this.indexList)
            {
                result += this.charToIndexList[index];
            }
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

        public bool generateNextCombination()
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
        {// 1 4 3 1
            int maxIndex = this.sourseStringLength - 2;
            while (
                maxIndex >= 0 
                && this.indexList[maxIndex] >= this.indexList[maxIndex + 1]
            )
            {
                maxIndex--;
            }
            return maxIndex;//++
        }

        public int findPremaxIndex(int maxSwapIndex)
        {
            int premaxSwapIndex = this.sourseStringLength - 1;
            while (
                premaxSwapIndex >= 0
                && this.indexList[maxSwapIndex] >= this.indexList[premaxSwapIndex]
                )
            {
                premaxSwapIndex--;
            }
            //premaxSwapIndex++;
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
