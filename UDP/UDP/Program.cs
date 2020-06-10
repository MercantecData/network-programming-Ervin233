using System;

namespace UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            // har lavet en menu hvor man kan vælge at være server eller client.
            Console.WriteLine("Skriv 1 for at være Server");
            Console.WriteLine("skriv 2 for at være client");

            //Gets the input from the console
            string input = Console.ReadLine();
            if (input == "1")
            {
                new Server();
            }
            else if (input == "2")
            {
                new Client();
            }
        }
    }
}
