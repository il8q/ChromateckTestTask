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
                List<string> combination = result.FindAll(current => current == element);
                if (combination.Count > 1)
                {
                    throw new Exception(
                        String.Format("комбинация {0} уже существует. Комбинации {1}",
                        element, 
                        String.Join(", ", combination.ToArray())
                    ));
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
/*                CombinatorInterface combinationGenerator = CombinatorBuilderDirector.createCombinator("4123");
*/              do
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
                Console.WriteLine(exception.StackTrace);
            }
        }
    }
}
