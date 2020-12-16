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

          //  foreach(string alias in )
           // commands.Add()
        }

    }
}
