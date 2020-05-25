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

            client.Close();

        }
    }
}
