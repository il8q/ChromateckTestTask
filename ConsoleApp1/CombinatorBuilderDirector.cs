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
            return CombinatorBuilderDirector.generateFinishCombinator(sourceString);
        }

        /*
         * Нужен для тестирования, так как для тестирования нужен не экземпляр
         * интерфейса(используется в консольном приложении, так как там доступ к полям
         * генератора не нужен)
         */
        protected static CombinationGenerator generateFinishCombinator(string sourceString)
        {
            CombinatorBuilder builder = new CombinatorBuilder();
            builder.createEmptyCombinator();
            builder.setStringData(sourceString);
            builder.generateCharIndexes();
            return builder.result;
        }
    }
}
