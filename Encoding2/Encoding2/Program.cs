using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace Encoding2
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 5002;
            bool running = true;

            menu();
            while(running)
            {
                string input = Console.ReadLine();

                Console.Clear();
                menu();

                if (input == "1")
                {
                    serverfunc(port);
                }
                else if (input == "2")
                {
                    clientfunc(port);
                }
                else if (input == "3")
                {
                    running = false;
                }
                else
                {
                    Console.WriteLine("du skal skrive 1 eller 2");
                }
            }





        }

        static void clientfunc(int port)
        {
            TcpClient client = new TcpClient();
            Console.WriteLine("Skriv serverens ip adresse");
            string serverIP = Console.ReadLine();
            IPAddress ip = IPAddress.Parse(serverIP);
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            client.Connect(endpoint);
            NetworkStream stream = client.GetStream();

            Console.WriteLine("skriv din besked");
            string text = Console.ReadLine(); ;
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);


            IPAddress ip1 = IPAddress.Any;
            IPEndPoint endpoint1 = new IPEndPoint(ip1, port);

            TcpListener listener = new TcpListener(endpoint1);
            listener.Start();

            TcpClient client1 = listener.AcceptTcpClient();

            NetworkStream stream1 = client1.GetStream();

            byte[] buffer1 = new byte[255];

            int NumberOfBytes = stream1.Read(buffer1, 0, 255);

            string converted = Encoding.UTF8.GetString(buffer1, 0, NumberOfBytes);

            Console.WriteLine(converted);

            listener.Stop();

        }

        static void serverfunc(int port)
        {

            IPAddress ip1 = IPAddress.Any;
            IPEndPoint endpoint1 = new IPEndPoint(ip1, port);

            TcpListener listener = new TcpListener(endpoint1);
            listener.Start();

            Console.WriteLine("Awaiting Clients....");

            TcpClient client1 = listener.AcceptTcpClient();

            NetworkStream stream1 = client1.GetStream();

            byte[] buffer1 = new byte[255];

            int NumberOfBytes = stream1.Read(buffer1, 0, 255);

            string converted = Encoding.UTF8.GetString(buffer1, 0, NumberOfBytes);

            Console.WriteLine(converted);

            listener.Stop();

            TcpClient client = new TcpClient();
            Console.WriteLine("Skriv serverens ip adresse");
            IPAddress ip = IPAddress.Parse("172.16.113.179");
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            client.Connect(endpoint);
            NetworkStream stream = client.GetStream();

            byte[] buffer = Encoding.UTF8.GetBytes("Det virkede!!");
            stream.Write(buffer, 0, buffer.Length);


          
        }
        static void menu()
        {
            Console.WriteLine("\n\n\nVil du være server eller client?");
            Console.WriteLine("Skriv 1 for at være server");
            Console.WriteLine("skriv 2 for at være client");
            Console.WriteLine("skriv 3 for at exit");
        }
    }
}
