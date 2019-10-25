using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RestAfgiftServer
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(name);

            TcpListener serverSocket = new TcpListener(ip, 7000);

            //Depricated style
            //TcpListener serverSocket = new TcpListener(6789);


            serverSocket.Start();
            

            //Ved hjælp af Task, så bliver der vedtaget concurrent, som gør det muligt at sende flere beskeder mellem serveren og clinten.
            while (true)
            {
                TcpClient connectionSocket = serverSocket.AcceptTcpClient();
                //Socket connectionSocket = serverSocket.AcceptSocket();
                Console.WriteLine("Server activated");
                EchoService service = new EchoService(connectionSocket);

                Task.Factory.StartNew((() => service.DoIt()));
            }

            serverSocket.Stop();

        }
    }
}
