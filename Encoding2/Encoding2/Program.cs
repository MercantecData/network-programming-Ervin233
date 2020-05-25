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
            TcpClient client = new TcpClient();
            int port = 5002;
            IPAddress ip = IPAddress.Parse("172.16.113.179");
            IPEndPoint endpoint = new IPEndPoint(ip, port);
            client.Connect(endpoint);
            NetworkStream stream = client.GetStream();


            string text = "hello world!";
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);

            //client.Close();


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
            

            //client1.Close();

        }
    }
}
