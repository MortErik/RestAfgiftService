using System;
using System.IO;
using System.Net.Sockets;

namespace RestAfgiftClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadLine();
            TcpClient clientSocket = new TcpClient("127.0.0.1", 7000);
            Console.WriteLine("Client ready");

            Stream ns = clientSocket.GetStream();  //provides a Stream
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing


            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Hvad koster din bil?");
                string message = Console.ReadLine();
                sw.WriteLine(message);
                string serverAnswer = sr.ReadLine();
                Console.WriteLine("Hvilken type bil har du?");
                Console.WriteLine("Server: " + serverAnswer);
                
                string biltype = Console.ReadLine();
                sw.WriteLine(biltype);
                sw.WriteLine();
                serverAnswer = sr.ReadLine();

                Console.WriteLine("Afgift af bilen" + serverAnswer);
                Console.WriteLine("No more from server. Press Enter");
                Console.ReadLine();
            }

            //string message = Console.ReadLine();
            //sw.WriteLine(message);
            //string serverAnswer = sr.ReadLine();

            //Console.WriteLine("Server: " + serverAnswer);

            //Console.WriteLine("No more from server. Press Enter");
            //Console.ReadLine();



            ns.Close();

            clientSocket.Close();

        }

    }
}
