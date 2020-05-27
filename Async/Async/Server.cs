using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Async
{
    public class Server
    {
        public Server(int port)
        {
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();
            Console.WriteLine("Awaiting Clients...");
            TcpClient client = listener.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            ReceiveMessage(stream);
            Console.Write("Write your message here: ");

            while (true)
            {

                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);
                stream.Write(buffer, 0, buffer.Length);
            }



        }
        public async void ReceiveMessage(NetworkStream stream)
        {
            byte[] buffer = new byte[255];

            while (true)
            {

                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 255);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);
                Console.Write("\n" + receivedMessage);

            }


        }
    }
}
