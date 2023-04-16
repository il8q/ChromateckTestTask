using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    class FactorialGenerator
    {
        public static int generate(int number)
        {
            int result = 1;
            for (int current = number; current > 1; current--)
            {
                result *= current;
            }
            return result;
        }
    }
}
