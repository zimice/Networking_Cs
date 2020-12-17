using System;
using System.Collections.Generic;
using System.Text;

namespace TCPServer
{
    public class TimeCommand : Command
    {
        public string[] Alias() {
            string[] aliases = {"cas","time","timedate" };
        }
        public string Execute() {
            return DateTime.Now();
        }

        public string getHelp() {
            return "vrati cas";
        }
    }
}
