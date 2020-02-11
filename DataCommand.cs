using System;
using System.Collections.Generic;
using System.Text;

namespace DIP
{
    public abstract class DataCommand
    {
        public string Output { get;  set; }
        public bool Exited { get; set; }
        
        public string _promptString { get; set; }

        public void ExecuteCommand(Command command)
        {
            try
            {
                command.Launch();
                if (Output.Length > 0)
                {
                    Console.WriteLine(Output);
                }
            }
            catch (InvalidOperationException)
            {
                Console.Error.WriteLine("{0}: path not found", command);
            }
        }

        public string Prompt()
        {
            Console.Write(_promptString);
            string userCommand = Console.ReadLine();
            return userCommand;
        }

        public Command PromptCommand()
        {
            string commandLine = Prompt();
            return new Command(commandLine);
        }

    }
}
