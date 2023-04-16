using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    public class CombinatorBuilder
    {
        public CombinationGenerator result;

        public void createEmptyCombinator()
        {
            this.result = new CombinationGenerator();
        }

        public void setStringData(string sourseString)
        {
            this.result.sourseStringLength = sourseString.Length;

            this.result.maxCombinationMumber = FactorialGenerator.generate(this.result.sourseStringLength);
            //this.result.maxCombinationMumber = this.result.maxCombinationMumber 
            //    / (this.result.sourseStringLength - variantsCount + 1);
        }
    }
}
