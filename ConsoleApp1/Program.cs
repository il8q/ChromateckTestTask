using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static bool checkResult(List<string> result)
        {
            
            foreach (string element in result)
            {
                if (result.FindAll(current => element == element).Count > 1)
                {
                    throw new Exception(String.Format("комбинация {0} уже существует", element));
                }
            }
            return true;
        }

        static void Main(string[] args)
        {
            try
            {
                List<string> result = new List<string>();
                //CombinationGenerator combinationGenerator = new CombinationGenerator(args[0]);
                CombinatorInterface combinationGenerator = CombinatorBuilderDirector.createCombinator("aabc");
                do
                {
                    result.Add(combinationGenerator.generateUniqueString());
                    Console.WriteLine(result.Last());
                }
                while (!combinationGenerator.printAllCombinations());
                checkResult(result);
            } 
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
