using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CombinatorInterface combinationGenerator = CombinatorBuilderDirector.createCombinator(args[0]);
                do
                {
                    Console.WriteLine(combinationGenerator.generateUniqueString());
                }
                while (!combinationGenerator.printAllCombinations());
            } 
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
            }
        }
    }
}
