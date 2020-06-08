using System;
using System.Text;

namespace Encoding1
{
    class Program
    {
        static void Main(string[] args)
        {
            //convert a byte to a string 
            string encoding = "Jeg håber du får en god dag";
            byte[] bytes = Encoding.UTF8.GetBytes(encoding);
            foreach (var b in bytes)
            {
                Console.WriteLine(b);
            }
            //Converts from bytes to string
            string converted = Encoding.UTF8.GetString(bytes);

            //Print the message "Jeg håber du får en god dag"
            Console.WriteLine(converted);
        }
    }
}
