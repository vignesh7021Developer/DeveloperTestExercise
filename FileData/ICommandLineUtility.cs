using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
  public  interface ICommandLineUtility
    {
        //This dictionary holds the list of command options and their associated actions
        Dictionary<string[],Func<string[],string>> CommandsActions { get; set; }
        //this validate checks whether the command is valid or not
        FileDataResult Validate(string[] opts);
        //Load commands and associated actions during runtime
        void LoadCommandsActions();
        //Execute the necessary action
        FileDataResult Execute(string[] options);
    }
}
