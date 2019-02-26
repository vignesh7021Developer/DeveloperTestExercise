using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    //This is InMemory data store which is abstracted by File Data repository
   public class FileDataRepository : IRepository
    {
        public IEnumerable<Command> CommandList { get; set; }
        public IEnumerable<ApplicationResources> AppResources { get; set; }

        public FileDataRepository()
        {
            CommandList = new List<Command>
            {
                new Command()
                {
                    CommandName="Version",
                    CommandOptions=new List<string>() {"-v","--v","/v","--version" }
                },
                new Command()
                {
                    CommandName="Size",
                    CommandOptions=new List<string>() {"-s","--s","/s","--size" }
                },

            };

            AppResources = new List<ApplicationResources>
            {
                new ApplicationResources()
                {
                    Name="InvalidNumberOfOptions",
                    Value="Invalid number of options"
                },
                new ApplicationResources()
                {
                    Name="InvalidOptions",
                    Value="Invalid options"
                },
                new ApplicationResources()
                {
                    Name="InvalidOperation",
                    Value="Invalid operation"
                }

            };
        }
        public IEnumerable<ApplicationResources> GetAllAppResources()
        {
            return AppResources;
        }

        public IEnumerable<string> GetAllCommandOptionsByCommandName(string name)
        {
            return CommandList.First(n => n.CommandName == name).CommandOptions;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return CommandList;
        }
    }
}
