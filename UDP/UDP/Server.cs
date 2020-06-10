using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
namespace UDP
{
    public class Server
    {
        public Server()
        {
            Receiver();
            Console.ReadLine();
        }

        public static async void Receiver()
        {
            //Creates a new endpoint with all ip adresses, and port 1234
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 1234);

            //Creates new udp client
            UdpClient client = new UdpClient(endpoint);

            //Awaitng client 
            UdpReceiveResult result = await client.ReceiveAsync();

            //Gets results 
            byte[] buffer = result.Buffer;

            //Convert to string from bytes
            string text = Encoding.UTF8.GetString(buffer);

            //Print the recieved message + text
            Console.WriteLine("Received: " + text);

        }
    }
}
