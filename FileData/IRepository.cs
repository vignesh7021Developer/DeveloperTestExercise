using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
   public interface IRepository
    {
        IEnumerable<Command> GetAllCommands();
        IEnumerable<string> GetAllCommandOptionsByCommandName(string name);
        IEnumerable<ApplicationResources> GetAllAppResources();
    }

    //InMemory database entities
    public class Command
    {
        public string CommandName { get; set; }
        public List<string> CommandOptions { get; set; }
    }

    public class ApplicationResources
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
