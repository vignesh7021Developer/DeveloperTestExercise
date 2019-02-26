using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        
        public static void Main(string[] args)
        {
            //complete functionality encapsulated inside FileDatUtility which is implementing IcommandLineUtility
            IRepository repository = new FileDataRepository();
            IParser parser = new CommandLineParser(repository);
            ICommandLineUtility fileUtility = new FileDataUtility(parser,repository);
            try
            {
                fileUtility.LoadCommandsActions();
                var validationResult = fileUtility.Validate(args);
                if (validationResult.Status)
                {
                    var executionResult = fileUtility.Execute(args);
                    Console.WriteLine(executionResult.ResultMessage);
                    Console.ReadKey();
                }else
                {
                    Console.WriteLine(validationResult.ResultMessage);
                    Console.ReadKey();
                }
            }
           
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
