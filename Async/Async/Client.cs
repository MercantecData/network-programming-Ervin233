using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Async
{
    public class Client
    {
        public Client(int port)
        {

            TcpClient client = new TcpClient();
            IPAddress ip = IPAddress.Parse("172.16.113.179");
            IPEndPoint endpoint = new IPEndPoint(ip, port);

            client.Connect(endpoint);

            NetworkStream stream = client.GetStream();
            receivedMessage(stream);
            while (true)
            {
                Console.WriteLine("Write your message here");




                string text = Console.ReadLine();
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                stream.Write(buffer, 0, buffer.Length);
            }

                client.Close();
            
                
        }

        internal static object Getstream()
        {
            throw new NotImplementedException();
        }

        public async void receivedMessage(NetworkStream stream) {
            byte[] buffer = new byte[255];

            while (true)
            {
                int numberofbytesread = await stream.ReadAsync(buffer, 0, 255);
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberofbytesread);

                Console.Write("\n" + receivedMessage);
            }
            

                
            
            
        }

    }
}
 