using System;
using System.Text;

namespace Encoding1
{
    class Program
    {
        static void Main(string[] args)
        {
            string encoding = "Jeg håber du får en god dag";
            byte[] bytes = Encoding.UTF8.GetBytes(encoding);
            foreach (var b in bytes)
            {
                Console.WriteLine(b);
            }
            string converted = Encoding.UTF8.GetString(bytes);
            Console.WriteLine(converted);
        }
    }
}
