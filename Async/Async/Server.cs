using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Async
{
    public class Server
    {
        //Creates a new list 
        public List<TcpClient> clients = new List<TcpClient>();



        public Server(int port)
        {
            //Listening to all IPAdresses
            IPAddress ip = IPAddress.Any;

            //Creates a new endoint
            IPEndPoint localEndpoint = new IPEndPoint(ip, port);

            //Creates a new tcplistener
            TcpListener listener = new TcpListener(localEndpoint);

            // start the listener 
            listener.Start();

            //Accepts the clients
            AcceptClients(listener);


            while (true)
            {
                Console.Write("Write your message here: ");

                //Gets the message from the console 
                string text = Console.ReadLine();

                //Convert to bytes 
                byte[] buffer = Encoding.UTF8.GetBytes(text);


                foreach (TcpClient client in clients)
                {
                    //Sends messages to all the clients
                    client.GetStream().Write(buffer, 0, buffer.Length);
                }



            }

        }
        public async void AcceptClients(TcpListener listener)
        {
            bool isRunning = true;
       
            while (isRunning)
            {
                // Waiting for the listener to accept 
                TcpClient client = await listener.AcceptTcpClientAsync();

                //Add Client
                clients.Add(client);

                //Gets input from stream 
                NetworkStream stream = client.GetStream();

                ReceiveMessage(stream);

            }



        }
        public async void ReceiveMessage(NetworkStream stream)
        {
            //creates a new buffer
            byte[] buffer = new byte[255];
            while (true)
            {
                //await stream and reading the number of bytes
                int numberOfBytesRead = await stream.ReadAsync(buffer, 0, 255);

                //gets a message and convert it to a string from a byte
                string receivedMessage = Encoding.UTF8.GetString(buffer, 0, numberOfBytesRead);

                //Prints the receivedmessage
                Console.Write("\n" + receivedMessage);

            }


        } 
    }
}
