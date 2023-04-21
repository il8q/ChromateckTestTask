namespace CombinatorTests
{
    class CombinatorBuilderDirector: CombinatorGenerator.CombinatorBuilderDirector
    {
        public static CombinatorGenerator.CombinationGenerator createTestCombinator(string sourceString)
        {
            CombinatorGenerator.CombinationGenerator result = createPublicCombinator(sourceString);
            result.printForConsole = false;
            return result;
        }
    }
}
