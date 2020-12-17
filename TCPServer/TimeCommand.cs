using System;
using System.Collections.Generic;
using System.Text;
namespace TCPServer
{
    public class TimeCommand : Command
    {
        public override string[] Alias() {
            string[] aliases = {"cas","time","timedate" };
            return aliases;
        }
        public override string Execute() {
            return DateTime.Now.ToString();
        }

        public override string getHelp() {
            return "vrati cas";
        }
    }
}
