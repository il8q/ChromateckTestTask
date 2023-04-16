using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombinatorGenerator;

namespace CombinatorTests
{
    class CombinatorBuilderDirector
    {
        public static CombinationGenerator createTestCombinator(string sourceString)
        {
            CombinatorBuilder builder = new CombinatorBuilder();
            builder.createEmptyCombinator();
            builder.setStringData(sourceString);
            return builder.result;
        }
    }
}
