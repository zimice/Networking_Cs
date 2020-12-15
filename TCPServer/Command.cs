using System;
using System.Collections.Generic;
using System.Text;

namespace TCPServer
{
    abstract class Command
    {
        public abstract string[] Alias() ;
        public abstract string Execute();

        public abstract string getHelp();
    }
}
