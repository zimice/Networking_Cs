using System;
using System.Collections.Generic;
using System.Text;

namespace TCPServer
{
    public class HelpCommand : Command

    {
        private static string commandList ;
        public HelpCommand() {
            commandList = "" + getHelp();
        }


        public override string[] Alias()
        {
            string[] aliases = {"help","info" };
            return aliases;
        }

        public override string Execute()
        {
            return commandList;
        }

        public override string getHelp()
        {
            return "List all commands and their info";
        }
        public void addEntry(string commandEntry) {
            commandList += "\n" + commandEntry;
        }
    }
}
