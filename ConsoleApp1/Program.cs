using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //args[0] = "asd";
            //CombinationGenerator combinationGenerator = new CombinationGenerator(args[0]);
            CombinationGenerator combinationGenerator = new CombinationGenerator("aabc");
            do
            {
                Console.WriteLine(combinationGenerator.generateUniqueString());
            }
            while (!combinationGenerator.printAllCombinations());
        }
    }
}
