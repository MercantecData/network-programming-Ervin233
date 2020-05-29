using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Async
{
    public class Server
    {
        public List<TcpClient> clients = new List<TcpClient>();



        public Server(int port)
        {
            IPAddress ip = IPAddress.Any;
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);
            TcpListener listener = new TcpListener(localEndpoint);
            listener.Start();

            AcceptClients(listener);


            while (true)
            {
                Console.Write("Write your message here: ");
                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);


                foreach (TcpClient client in clients)
                {
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }



            }

        }
        public async void AcceptClients(TcpListener listener)
        {
            bool isRunning = true;
            while (isRunning)
            {
                TcpClient client = await listener.AcceptTcpClientAsync();
                clients.Add(client);
                NetworkStream stream = client.GetStream();
                ReceiveMessage(stream);

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
