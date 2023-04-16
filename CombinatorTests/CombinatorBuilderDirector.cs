using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombinatorGenerator;

namespace CombinatorTests
{
    class CombinatorBuilderDirector: CombinatorGenerator.CombinatorBuilderDirector
    {
        public static CombinationGenerator createTestCombinator(string sourceString)
        {
            CombinationGenerator result = generateFinishCombinator(sourceString);
            result.printForConsole = false;
            return result;
        }
    }
}
