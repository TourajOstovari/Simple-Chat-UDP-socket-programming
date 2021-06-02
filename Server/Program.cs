using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server
{
    class Program
    {

        private const int listenPort = 50000;

        static void Main(string[] args)
        {
            bool done = false;
            UdpClient listener = new UdpClient(listenPort);
            IPEndPoint groupEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), listenPort);
            string data_recieved;
            byte[] recieve_byte_array;
            try
            {
                while (!done)
                {
                    Console.WriteLine("Waiting for an Message to come in...");
                    recieve_byte_array = listener.Receive(ref groupEP);
                    Console.WriteLine("You got an message from {0}", groupEP.ToString());
                    data_recieved = Encoding.ASCII.GetString(recieve_byte_array, 0, recieve_byte_array.Length);
                    Console.WriteLine(data_recieved);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
