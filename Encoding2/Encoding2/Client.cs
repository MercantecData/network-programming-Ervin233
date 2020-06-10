using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Encoding2
{
    public class Client
    {
        public Client(int port)
        {
            // Connects to server
            Console.WriteLine("Skriv serverens ip adresse");
            string serverIP = Console.ReadLine();

            while (true)
            {
                //Connect with a serverIP or port
                TcpClient client = connect(serverIP, port);

                Console.WriteLine("Skriv din besked");
                string text = Console.ReadLine();

                // Send message to server
                sendMessage(text, client);

                // Start listener
                TcpListener listener = StartListener(port);

                // Get message from server
                getMessageFromStream(listener);
            }
        }

        static TcpClient connect(string serverIP, int port)
        {
            //Creates a new client
            TcpClient client = new TcpClient();

            //Converting a string to my IPAdress
            IPAddress ip = IPAddress.Parse(serverIP);

            //Creates a new IpendPoint
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            //Connecting to my client 
            client.Connect(endPoint);

            //Returning the client 
            return client;
        }
        static void sendMessage(string text, TcpClient client)
        {
            //Reads the input from stream
            NetworkStream stream = client.GetStream();

            //convert text to bytes
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            //Reads the stream write 
            stream.Write(buffer, 0, buffer.Length);
        }
        static TcpListener StartListener(int port)
        {
            //Listening to all IPAdress
            IPAddress ip1 = IPAddress.Any;

            //Creates a new ipendpointto ip and port
            IPEndPoint endpoint1 = new IPEndPoint(ip1, port);

            //Creates a new Tcplistener
            TcpListener listener = new TcpListener(endpoint1);

            //Starts the listener
            listener.Start();

            // Returns the listener 
            return listener;
        }
        static void getMessageFromStream(TcpListener listener)
        {
            //Creates a client 
            TcpClient client1 = listener.AcceptTcpClient();

            //reads the input from stream
            NetworkStream stream1 = client1.GetStream();

            //creates a new buffer
            byte[] buffer1 = new byte[255];

            //get numbers from byte
            int numberOfBytes = stream1.Read(buffer1, 0, 255);

            //converts byte to string
            string converted = Encoding.UTF8.GetString(buffer1, 0,
            numberOfBytes);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(converted);
            Console.ResetColor();

            //stop listener
            listener.Stop();
        }
    }
}
