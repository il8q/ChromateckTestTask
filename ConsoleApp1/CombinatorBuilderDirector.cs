using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class CombinatorBuilderDirector
    {
        public static CombinatorInterface createCombinator(string sourceString)
        {
            CombinatorBuilder builder = new CombinatorBuilder();
            builder.createEmptyCombinator();
            builder.setStringData(sourceString);
            builder.findNotUniqueChars();
            builder.findIgnoreIndexChars();
            return builder.result;
        }
    }
}
