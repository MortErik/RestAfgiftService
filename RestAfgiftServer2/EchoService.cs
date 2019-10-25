using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using Afgift;

namespace RestAfgiftServer2
{
    public class EchoService
    {
        private TcpClient connectionSocket;


        public EchoService(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this.connectionSocket = connectionSocket;

        }
        internal void DoIt()
        {
            //Initializing streams here or in constructor
            Stream ns = connectionSocket.GetStream();
            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);
            sw.AutoFlush = true; // enable automatic flushing

            string message = sr.ReadLine();
            string answer;


            //Målet ved denne løkke var at den skulle bruge ddl filen og tag fat i metoderne fra den forrige opgave "Afgift",
            //da det ikke var en mulighed, så tog jeg en if-statement og kommunikerede via den til clienten.
            //og derved var det muligt at sende flere beskeder end kun den ene.

            while (message != null && message != "")
            {
                int pris = Int32.Parse(message);
                //Console.WriteLine("Bil pris: " + message + " kroner");
                sw.WriteLine(pris);
                message = sr.ReadLine();
                string bilType = sr.ReadLine();

                if (bilType == "benzin")
                {
                    answer = Convert.ToString(Afgift.BilAfgift.AfgiftTilBil(pris));
                    Console.WriteLine("Afgiften af bilen" + answer);
                    answer = sr.ReadLine();
                    sw.WriteLine(answer);
                    //int afgift = Afgift.BilAfgift.AfgiftTilBil(50000);
                }
                else if (bilType == "el")
                {
                    answer = Convert.ToString(Afgift.BilAfgift.AfgiftTilBil(pris));
                    Console.WriteLine("Afgiften af bilen" + answer);
                    answer = sr.ReadLine();
                    sw.WriteLine(answer);
                }

                message = sr.ReadLine();

            }
            ns.Close();
            connectionSocket.Close();
        }

    }
}
