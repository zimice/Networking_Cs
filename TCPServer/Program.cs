using System;

namespace TCPServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server(65525);
        }
    }
}
