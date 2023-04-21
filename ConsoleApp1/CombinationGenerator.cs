using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    public class CombinationGenerator: CombinatorInterface
    {
        public string sourceString;
        public int currentCombinationNumber = 0;
        public int sourseStringLength;
        public int maxCombinationMumber = 0;
        public bool printForConsole = true;

        public List<int> ignoreIndexChars = new List<int>();
        public int combinationCountForFirstChar;
        public int charVariantsCount;
        public Dictionary<char, int> notUniqueChars;

        private int _printCounter = 1;

        public string GenerateUniqueString()
        {
            string result = "";

            int firstCharIndex = this.ChangeFirstSequenceCharIndex();
            result += this.sourceString[firstCharIndex];
            result += this.GenerateSequenceWithoutFirstChar(firstCharIndex);

            if (this.printForConsole)
            {
                result = string.Format("{0}. combination seed {1}. {2}", this._printCounter++, this.currentCombinationNumber, result);
            }
            this.currentCombinationNumber++;

            this.SkipIgnoredCharCombinations();
            return result;
        }

        private void SkipIgnoredCharCombinations()
        {
            int nextPermutationSeed = this.GetCharIndex(this.currentCombinationNumber);
            while (
                this.ignoreIndexChars.Contains(nextPermutationSeed)
                && !PrintAllCombinations()
                )
            {
                this.SkipTheCharVariants(nextPermutationSeed);
                nextPermutationSeed = this.GetCharIndex(this.currentCombinationNumber);
            }
        }

        private int ChangeFirstSequenceCharIndex()
        {
            int result = this.GetCharIndex(this.currentCombinationNumber);
            if (this.NeedSkipDublicates())
            {
                result = this.SkipEquivalentCombinationsForFirstChar(result);
            }
            return result;
        }

        private bool NeedSkipDublicates()
        {
            return this.charVariantsCount < this.sourseStringLength;
        }

        private int SkipEquivalentCombinationsForFirstChar(int result)
        {
            int temp = this.currentCombinationNumber;

            if (PrintAllCombinations())
            {
                return this.sourseStringLength - 1;
            }

            int permutationSeed = this.currentCombinationNumber % (this.maxCombinationMumber / this.sourseStringLength);
            // currentSeedOnStartCombinationSet=true - означает что мы только начинаем перебирать комбинации
            // для первого выбранного символа
            bool currentSeedOnStartCombinationSet = permutationSeed == 0;
            if (currentSeedOnStartCombinationSet)
            {
                int uniqueCombinationCount = this.GetCombinationCount(
                    this.sourseStringLength - 1, 
                    this.sourceString[result]
                );
                this.currentCombinationNumber += this.combinationCountForFirstChar - uniqueCombinationCount;
            }
            return result;
        }

        private bool RemainLastSetForFirstChar()
        {
            bool value = this.currentCombinationNumber <
            (
                this.maxCombinationMumber /
                this.sourseStringLength * (this.sourseStringLength - 1)
            );
            return value;
        }

        private void SkipTheCharVariants(int charIndex)
        {
            char currentChar = this.sourceString[charIndex];
            this.currentCombinationNumber += this.combinationCountForFirstChar;
        }

        private int GetCharIndex(int seed)
        {
            return (int)Math.Ceiling(
                (double)(seed / this.combinationCountForFirstChar)
            );
        }

        private string GenerateSequenceWithoutFirstChar(int firstCharIndex)
        {
            string result = "";
            string tempString = this.sourceString;

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

        private int GetCombinationCount(int stringLength, char ignoredChar)
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

        public bool PrintAllCombinations()
        {
            return this.currentCombinationNumber >= this.maxCombinationMumber;
        }
    }
}
