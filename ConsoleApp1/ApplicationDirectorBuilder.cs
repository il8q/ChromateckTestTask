using CombinatorGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationGenerator
{
    public class ApplicationDirectorBuilder
    {
        public static Application CreateApplication(string[] commandLineArguments)
        {
            ApplicationBuilder builder = new ApplicationBuilder();
            builder.CreateEmptyCombinator();
            builder.CreateCombinationGenerator(commandLineArguments);
            return builder.result;
        }
    }
}
