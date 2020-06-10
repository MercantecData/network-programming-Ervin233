using System.Net.Sockets;
using System.Net;
using System.Text;
namespace UDP
{
    public class Client
    {
        public Client()
        {
            //Creates a new udp client 
            UdpClient client = new UdpClient();

            //Sending a message "Hello UDP!"
            string text = "Hello UDP!";

            //Converts to bytes
            byte[] bytes = Encoding.UTF8.GetBytes(text);

            //Creates a new endpoint with a IPAdress and port 
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("172.16.113.146"), 1234);

            //Sends the message to server 
            client.Send(bytes, bytes.Length, endpoint);
        }
    }
}