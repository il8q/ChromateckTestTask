using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CombinatorBuilder
    {
        public CombinationGenerator result;

        public void createEmptyCombinator()
        {
            this.result = new CombinationGenerator();
        }

        public void setStringData(string sourseString)
        {
            int startIndex = 0;
            int variantsCount = 0;
            foreach (char current in sourseString)
            {
                if (!this.result.charIndexes.Contains(current))
                {
                    variantsCount++;
                }
                this.result.charIndexes.Add(current);
                startIndex++;
            }
            this.result.sourceCharIndexes = this.result.charIndexes.ToList();
            this.result.sourseStringLength = startIndex;

            this.result.maxCombinationMumber = FactorialGenerator.generate(this.result.sourseStringLength);
            this.result.maxCombinationMumber = this.result.maxCombinationMumber 
                / (this.result.sourseStringLength - variantsCount + 1);
        }
    }
}
