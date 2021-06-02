using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            bool exception_thrown = false;


            Socket sending_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            string IP;
            IPEndPoint sending_end_point = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 50000); // 50000 is the port but you can choose every port over 1000 to 80000 i guess.

            Console.WriteLine("Enter the message you want to send: ");
            Console.WriteLine("Enter nothing to exit. ");
            while (!done)
            {
                Console.WriteLine("Enter text to send and blank line to quit. ");
                string text_to_send = Console.ReadLine();
                if (text_to_send.Length == 0)
                {
                    done = true;
                }
                else
                {
                    byte[] send_buffer = Encoding.ASCII.GetBytes(text_to_send);

                    Console.WriteLine("Sending the message to the IP: {0} port: {1}",
                                        sending_end_point.Address,
                                        sending_end_point.Port);
                    try
                    {
                        sending_socket.SendTo(send_buffer, sending_end_point);
                    }
                    catch (Exception send_exception)
                    {
                        exception_thrown = true;
                        Console.WriteLine("Exception {0}", send_exception);
                    }
                    if (exception_thrown == false)
                    {
                        Console.WriteLine("Message has been send to the IP Adress");
                    }
                    else
                    {
                        exception_thrown = false;
                        Console.WriteLine("The exception indicates the message was not sen");
                    }
                }
            }
        }
    }
}
