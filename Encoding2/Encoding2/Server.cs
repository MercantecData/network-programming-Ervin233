using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Encoding2
{
    public class Server
    {
        public Server(int port)
        {
            while (true)
            {
                // Starts listener
                TcpListener listener = StartListener(port);
                Console.WriteLine("Awaiting Clients...");

                // Gets message from client
                getMessageFromStream(listener);

                // Connects to client
                TcpClient client = connect("172.16.113.179", port);

                string text = "Det virkede!!!!!!!!!!";
                //Send response message to client
                sendMessage(text, client);
            }
        }

        static TcpClient connect(string serverIP, int port)
        {
            //Creates a new client 
            TcpClient client = new TcpClient();

            //Creates a new IPAdress
            IPAddress ip = IPAddress.Parse(serverIP);

            //Creates a new endpoint
            IPEndPoint endPoint = new IPEndPoint(ip, port);

            //Connect to the client with endpoint 
            client.Connect(endPoint);
            return client;
        }
        static void sendMessage(string text, TcpClient client)
        {
            //gets input from networkstream
            NetworkStream stream = client.GetStream();

            //Convert text to bytes
            byte[] buffer = Encoding.UTF8.GetBytes(text);

            //Reads the stream write 
            stream.Write(buffer, 0, buffer.Length);
        }
        static TcpListener StartListener(int port)
        {
            //Listening to all IPadadresses
            IPAddress ip1 = IPAddress.Any;

            //Creates a new endpoint to ip and port
            IPEndPoint endpoint1 = new IPEndPoint(ip1, port);

            //Creates a new Tcplistener
            TcpListener listener = new TcpListener(endpoint1);

            // starts the listener
            listener.Start();
            return listener;
        }
        static void getMessageFromStream(TcpListener listener)
        {
            //Creates a new client
            TcpClient client1 = listener.AcceptTcpClient();

            //reads the input from stream
            NetworkStream stream1 = client1.GetStream();

            //Creates a new buffer
            byte[] buffer1 = new byte[255];

            //gets numbers from byte
            int numberOfBytes = stream1.Read(buffer1, 0, 255);

            //Converts byte to string
            string converted = Encoding.UTF8.GetString(buffer1, 0,
            numberOfBytes);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(converted);
            Console.ResetColor();

            //Stop to listen
            listener.Stop();
        }
    }
}
