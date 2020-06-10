using System;

namespace Async
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hvilken Port?");

            //Converting to a int from a string 
            int port = Convert.ToInt32(Console.ReadLine());
            bool running = true;

            //The menu 
            menu();
            while (running)
            {
                //Gets the input from the console 
                string input = Console.ReadLine();
                
                // Clear the console
                Console.Clear();

                //Show the menu 
                menu();
                if (input == "1")
                {
                    new Server(port);
                }
                else if (input == "2")
                {
                    new Client(port);
                }
                else if (input == "3")
                {
                    running = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du skulle skrive 1 eller 2!!!!!!!!!");
                    Console.ResetColor();
                }
            }
        }
        static void menu()
        {
            Console.WriteLine("Vil du være server eller client");
            Console.WriteLine("Skriv 1 for at være server");
            Console.WriteLine("Skriv 2 for at være client");
            Console.WriteLine("Skriv 3 for at lukke programmet");
        }
    }
}
