using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPServer
{
    public class Server
    {
        private TcpListener _server;
        private Boolean _isRunning;

        public Server(int port = 27)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;

            LoopClients();
        }

        public void LoopClients()
        {
            while (_isRunning)
            {

                TcpClient newClient = _server.AcceptTcpClient();

                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;

            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);

            Boolean bClientConnected = true;
            String sData = null;

            sWriter.WriteLine("You are now connected to the C# vowel counter server");
            sWriter.WriteLine("List help for info about commands ");
            sWriter.Flush();

            while (bClientConnected)
            {
                sWriter.Flush();

                // sData = sReader.ReadLine();
                // sData = formatInput(sData);
                CommandExecutor cme = new CommandExecutor(sWriter,sReader);
                //VowelsCommand vowelC = new VowelsCommand(sWriter, sReader);
                sWriter.WriteLine("Zadej prikaz: ");
                // sWriter.WriteLine(vowelC.Execute());
                sWriter.WriteLine(cme.ExecuteCommand());
              //  sWriter.WriteLine("");
                sWriter.Flush();
            }
        }
        public string formatInput(string sData)
        {
            sData = sData.Trim();
            sData = sData.ToLower();
            return sData;
        }
    }
}
