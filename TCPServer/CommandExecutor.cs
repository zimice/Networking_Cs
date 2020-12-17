using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCPServer
{
    public class CommandExecutor
    {
        private static Dictionary<string, Command> commands;
        public CommandExecutor(StreamWriter sWriter, StreamReader sReader)
        {
            VowelsCommand vowelscomm = new VowelsCommand(sWriter,sReader);
            HelpCommand helpcomm = new HelpCommand();
            List<Command> commandList = new List<>();
            foreach (Command c  in commandList)
                foreach(string alias in c.Alias())
                 commands.Add(alias,commandList);

        }
        public string ExecuteCommand() {
            return commands.get(sReader.ReadLine());
        }
    }
}
