using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    public class CombinatorBuilderDirector
    {
        public static CombinatorInterface createCombinator(string sourceString)
        {
            return CombinatorBuilderDirector.createPublicCombinator(sourceString);
        }

        /*
         * Нужен для тестирования, так как для тестирования нужен не экземпляр
         * интерфейса(используется в консольном приложении, так как там доступ к полям
         * генератора не нужен)
         */
        protected static CombinationGenerator createPublicCombinator(string sourceString)
        {
            CombinatorBuilder builder = new CombinatorBuilder();
            builder.СreateEmptyCombinator();
            builder.SetStringData(sourceString);

            builder.СreateEmptyCombinator();
            builder.SetStringData(sourceString);
            builder.FindNotUniqueChars();
            builder.FindIgnoreIndexChars();
            return builder.result;
        }
    }
}
