using CombinationGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinatorGenerator
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                ApplicationInterface application = ApplicationDirectorBuilder.CreateApplication(args);
                return application.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                Console.WriteLine(exception.StackTrace);
                return Application.UNSUCCESS_EXECUTE;
            }
        }
    }
}
