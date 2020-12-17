using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TCPServer
{
    public class CommandExecutor
    {
        private static Dictionary<string, Command> commands = null;
        private static StreamReader reader;
        private static StreamWriter writer;
        public CommandExecutor(StreamWriter sWriter, StreamReader sReader)
        {
            writer = sWriter;
            reader = sReader;
            VowelsCommand vowelscomm = new VowelsCommand(sWriter,sReader);
            HelpCommand helpcomm = new HelpCommand();
            TimeCommand timecomm = new TimeCommand();
            List<Command> commandList = new List<Command>();
            commandList.Add(vowelscomm);
            commandList.Add(helpcomm);
            commandList.Add(timecomm);
            foreach (Command c in commandList)
                foreach (string alias in c.Alias())
                    commands.Add(alias, c);

        }
        public string ExecuteCommand() {
            return commands[reader.ReadLine()].Execute();
        }
    }
}
