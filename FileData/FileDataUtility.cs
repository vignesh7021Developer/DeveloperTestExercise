using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
   public class FileDataUtility : ICommandLineUtility
    {
        public IParser CommandLineParser  { get; set; }
        public IRepository Repository { get; set; }
        public FileDetails FileDetails { get; set; }
        public FileDataUtility(IParser parser,IRepository repository)
        {
            CommandLineParser = parser;
            Repository = repository;
            CommandsActions = new Dictionary<string[], Func<string[], string>>();
            FileDetails = new FileDetails();
        }
        public Dictionary<string[], Func<string[], string>> CommandsActions { get; set; }

        public FileDataResult Validate(string[] opts)
        {
            FileDataResult result = new FileDataResult();
            try
            {
                CommandLineParser.Parse(opts);
            }
            catch (InvalidNumberOfOptionsException ex)
            {
                result.Status = false;
                result.ResultMessage = ex.Message;
                return result;
            }
            catch (InvalidOperationException ex)
            {
                result.Status = false;
                result.ResultMessage = ex.Message;
                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.ResultMessage = ex.Message;
                return result;
            }
            result.Status = true;
            return result;
            
        }
        public FileDataResult Execute(string[] options)
        {
            FileDataResult result = new FileDataResult();
            result.Status = false;
            result.ResultMessage = Repository.GetAllAppResources().First(r => r.Name == "InvalidOperation").Value;
            foreach (var commandKey in CommandsActions.Keys)
            {
                if(commandKey.Any(c=>c.Equals(options[0])))
                {
                    result.Status = true;
                    result.ResultMessage = CommandsActions[commandKey].Invoke(options);
                    break;
                }
            }
            return result;
        }
        public void LoadCommandsActions()
        {
            CommandsActions.Add(Repository.GetAllCommandOptionsByCommandName("Version").ToArray(),(options)=> {
                return FileDetails.Version(options[options.Length-1]);
            });

            CommandsActions.Add(Repository.GetAllCommandOptionsByCommandName("Size").ToArray(), (options) => {
                return FileDetails.Size(options[options.Length - 1]).ToString();
            });

        }
    }
}
