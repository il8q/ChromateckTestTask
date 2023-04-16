using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    interface CombinatorInterface
    {
        string generateUniqueString();
        bool printAllCombinations();
        bool generateNextCombination(List<int> list, int sequenceLength);
    }
}
