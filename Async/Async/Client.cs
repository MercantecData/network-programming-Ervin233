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
            // Creates a new client 
            TcpClient client = new TcpClient();

            //creates a IPadress that i can connect to
            IPAddress ip = IPAddress.Parse("172.16.113.188");

            // Creates a new endpoint 
            IPEndPoint endpoint = new IPEndPoint(ip, port);

            // Connect to the client
            client.Connect(endpoint);

            //Gets the input from stream
            NetworkStream stream = client.GetStream();
            receivedMessage(stream);
            while (true)
            {
                Console.WriteLine("Write your message here");

                //Reads the things in the console 
                string text = Console.ReadLine();


                //Converts to bytes 
                byte[] buffer = Encoding.UTF8.GetBytes(text);

                //sends the message to stream
                stream.Write(buffer, 0, buffer.Length);
            }

            client.Close();


        }

        public async void receivedMessage(NetworkStream stream) {

            //Creates a new buffer
            byte[] buffer = new byte[255];

            while (true)
            {
                // Await stream and read number of bytes
                int numberofbytesread = await stream.ReadAsync(buffer, 0, 255);

                //Gets a message and conevert it to a string from a bytes
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberofbytesread);


                // Prints the recieved message 
                Console.Write("\n" + receivedMessage);
            }
            

                
            
            
        }

    }
}
 