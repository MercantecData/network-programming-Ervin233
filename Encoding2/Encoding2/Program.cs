using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Encoding2
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hvilken port??");

            //Converting to a int32.
            int port = Convert.ToInt32(Console.ReadLine());

            bool running = true;

            menu();
            // showing the menu

            while (running)
            {
                //Gets the input from the console
                string input = Console.ReadLine();

                //Clears the whole console
                Console.Clear();

                // Showing the menu 
                menu();
                if (input == "1")
                {
                        new Server(port);
                }
                else if (input == "2")
                {
                    Console.WriteLine("Skriv serverens ip adresse");

                    //Takes the ip from the console readline 
                    string serverIP = Console.ReadLine();
                    while (true)
                    {
                        new Client(port);
                    }
                    
                }
                else if (input == "3")
                {
                    running = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du skulle skrive 1 eller 2!!!!!!!!!");
                    //Error message you need to write a number between 1 and 2 

                    Console.ResetColor();
                }
            }
        }

        static void menu()
        {
            //made a menu where you can clcik from one to 1 to 3 
            Console.WriteLine("Vil du være server eller client");
            Console.WriteLine("Skriv 1 for at være server");
            Console.WriteLine("Skriv 2 for at være client");
            Console.WriteLine("Skriv 3 for at lukke programmet");
        }
    }
}
