using CombinationGenerator;
using System;

namespace CombinatorGenerator
{
    public class Application: ApplicationInterface
    {
        public const int SUCCESS_EXECUTE = 0;
        public const int UNSUCCESS_EXECUTE = 1;
        internal CombinatorInterface _combinationGenerator;

        public int Run()
        {
            try
            {
                do
                {
                    Console.WriteLine(this._combinationGenerator.GenerateUniqueString());
                }
                while (!this._combinationGenerator.PrintAllCombinations());
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
                return UNSUCCESS_EXECUTE;
            }
            return SUCCESS_EXECUTE;
        }
    }
}