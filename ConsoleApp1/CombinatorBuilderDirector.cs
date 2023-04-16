﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    class CombinatorBuilderDirector
    {
        public static CombinatorInterface createCombinator(string sourceString)
        {
            CombinatorBuilder builder = new CombinatorBuilder();
            builder.createEmptyCombinator();
            builder.setStringData(sourceString);
            return builder.result;
        }
    }
}
