using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
   public class CommandLineParser: IParser
    {
        public IRepository Repository { get; set; }

        public CommandLineParser(IRepository repository)
        {
            Repository = repository;
        }
       bool IParser.Parse(string[] options)
        {
            if(options== null || options.Length==0 || options.Length !=2)
            {
                throw new InvalidNumberOfOptionsException(Repository.GetAllAppResources().First(r=>r.Name== "InvalidNumberOfOptions").Value);
            }
            if (!Repository.GetAllCommandOptionsByCommandName("Version").Any(v => v.Equals(options[0])) && !Repository.GetAllCommandOptionsByCommandName("Size").Any(s => s.Equals(options[0])) || options[1]==string.Empty)
            {
                throw new InvalidOptionsException(Repository.GetAllAppResources().First(r => r.Name == "InvalidOptions").Value);
            }
            return true;
        }
    }

  public interface IParser
    {
        bool Parse(string[] options);
    }
}
