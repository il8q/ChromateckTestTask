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
        public int combinationShift;
        public Dictionary<char, int> ingoreCombinationCounts;
        public int charVariantsCount;
        public Dictionary<char, int> notUniqueChars;

        public string generateUniqueString()
        {
            /*            if (this.currentCombinationNumber > 0)
                        {
                            this.generateNextCombination();
                        }

                        string result = this.generateCurrentString();*/

            string result = "";
            int firstCharIndex = this.changeFirstSequenceCharIndex();
            result += this.sourceString[firstCharIndex];
            result += this.generateSequenceWithoutFirstChar(firstCharIndex);

            if (this.printForConsole)
            {
                return string.Format("{0}. combination seed {1}. {2}", this.printCounter++, this.currentCombinationNumber++, result);
            }
            this.currentCombinationNumber++;
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
            //this.currentCombinationNumber += this.combinationShift;

            // игнорируем повторяющиеся комбинации
            int permutationSeed = this.currentCombinationNumber % (this.sourseStringLength);
            if (permutationSeed >= (this.combinationCountForFirstChar - this.combinationShift))
            {
                this.currentCombinationNumber += this.combinationShift - 1;
            }
            return result;
        }

        private void skipTheCharVariants(int charIndex)
        {
            char currentChar = this.sourceString[charIndex];
            this.currentCombinationNumber += this.combinationCountForFirstChar;// * this.notUniqueChars[currentChar];
        }

        private int getCharIndex(int seed)
        {
            return (int)Math.Round(
                (double)(seed / this.combinationCountForFirstChar)//(this.sourseStringLength - 1)
            );
        }

        private string generateSequenceWithoutFirstChar(int firstCharIndex)
        {
            string result = "";
            String tempDict = this.sourceString;

            tempDict = tempDict.Remove(firstCharIndex, 1);//-1?
            int permutationSeed = this.currentCombinationNumber % (this.sourseStringLength - 1);
            char seedChar = this.sourceString[permutationSeed];

            for (int startIndex = tempDict.Length; startIndex > 0; startIndex--)
            {
                int currentIndex = this.currentCombinationNumber % startIndex;
                char currentChar = tempDict[currentIndex];

                bool lastEquealCurrent = false;
                if (result.Length > 0)
                {
                    lastEquealCurrent = result[result.Length - 1] == currentChar;
                }
                
                if (
                    this.ingoreCombinationCounts.ContainsKey(currentChar)
                    && currentIndex > 0
                    && lastEquealCurrent
                    )
                {
                    // currentIndex + tempDict.Length
                    int combination = FactorialGenerator.generate(tempDict.Length - currentIndex);
                    if (combination > 1)
                    {
                        this.currentCombinationNumber += combination;// (int)Math.Ceiling((double)combination / 2);//
                    }
                    
                    //
                }
                tempDict = tempDict.Remove(currentIndex, 1);
                result += currentChar;
            }

            result.Reverse();
            return result;
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
