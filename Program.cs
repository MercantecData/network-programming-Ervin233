using System;

namespace UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Skriv 1 for at være Server");
            Console.WriteLine("skriv 2 for at være client");

             string input = Console.ReadLine();
            if (input == "1")
            {
                new Server();
            }else if (input == "2")
            {
                new Client();
            }
        }
    }
}
