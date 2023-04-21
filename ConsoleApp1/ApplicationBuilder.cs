using CombinatorGenerator;
using System;

namespace CombinationGenerator
{
    internal class ApplicationBuilder
    {
        internal Application result;

        internal void CreateEmptyCombinator()
        {
            this.result = new Application();
        }

        internal void CreateCombinationGenerator(string[] args)
        {
            if (args.Length < 1)
            {
                throw new Exception("Укажите строку для выводы комбинаций");
            }
            this.result._combinationGenerator = CombinatorBuilderDirector.createCombinator(args[0]);
        }
    }
}