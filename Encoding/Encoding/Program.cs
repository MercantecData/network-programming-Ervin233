﻿using System;
using System.Text;

namespace Encoding1
{
    class Program
    {
        static void Main(string[] args)
        {
            string encoding = "Jeg håber du får en god dag";
            byte[] bytes = Encoding.ASCII.GetBytes(encoding);
            foreach (var b in bytes)
            {
                Console.WriteLine(b);
            }
        }
    }
}
