using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TCPServer
{
    public class TcpServer
    {
        private TcpListener _server;
        private Boolean _isRunning;

        public TcpServer(int port)
        {
            _server = new TcpListener(IPAddress.Any, port);
            _server.Start();

            _isRunning = true;

            LoopClients();
        }

        public void LoopClients()
        {
            Console.WriteLine("Server byl spusten");
            while (_isRunning)
            {
                // čeká na spojení klienta
                TcpClient newClient = _server.AcceptTcpClient();
                string clientIPAddress = "IP adresa klienta: " + 
                    IPAddress.Parse(((IPEndPoint)newClient.Client.RemoteEndPoint).Address.ToString());
                Console.WriteLine(clientIPAddress);

                // klient se spojil
                // vytvoření vlákna pro komunikaci s klientem
                Thread t = new Thread(new ParameterizedThreadStart(HandleClient));
                t.Start(newClient);
            }
        }

        public void HandleClient(object obj)
        {
            // získání klienta z parametru předaného vláknu
            TcpClient client = (TcpClient)obj;
            string clientIPAddress = "IP adresa klienta: " +
                    IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());

            // vytvoření streamů pro komunikaci
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.UTF8);
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.UTF8);

            Boolean bClientConnected = true;
            String sData = null;

            sWriter.WriteLine("Uspesne jste se pripojili na server.");
            sWriter.Flush();

            while (bClientConnected)
            {
                sWriter.WriteLine("\n\rServer> Mate nejaky pozadavek.");
                sWriter.Write("Klient> ");
                sWriter.Flush();

                // čtení ze streamu
                sData = sReader.ReadLine();
                //odseknuti bilych znaku ze zacatku a konce textoveho retezce
                sData = sData.Trim();
                //prevedeni malych pismen na velka
                sData = sData.ToUpper();
                string answer = "Server> "+sData+"?";
                sWriter.WriteLine(answer);
                sWriter.WriteLine("Server> Nechapu pozadavek.");
                sWriter.Flush();
            }
            /*
            string clientIPAddress = "Klient byl odpojen: " + IPAddress.Parse(((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());
            Console.WriteLine(clientIPAddress);
            client.Close();
            */
        }
    }
}
